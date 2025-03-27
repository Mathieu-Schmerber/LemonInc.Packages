using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine
{
    public partial class StateMachine
    {
        private readonly List<Transition> _anyTransitions = new();
        private readonly Dictionary<Type, StateNode> _nodes = new();
        private readonly List<StateGroup> _groups = new();
        [CanBeNull] private StateNode _current;

        [CanBeNull] public IState CurrentState => _current?.State;

        public StateNode RegisterState<T>()
            where T : IState, new()
        {
            var state = new T();
            var node = new StateNode(state);

            _nodes.Add(typeof(T), node);
            return node;
        }
        
        public StateNode RegisterState<T>(T instance)
            where T : IState
        {
            var node = new StateNode(instance);

            _nodes.Add(typeof(T), node);
            return node;
        }

        public StateGroup CreateGroup(params IState[] states)
        {
            var group = new StateGroup(this, states);
            
            _groups.Add(group);
            return group;
        }

        public void AddTransition<TFrom, TTo>(IPredicate predicate)
            where TFrom : IState
            where TTo : IState
        {
            var from = _nodes.GetValueOrDefault(typeof(TFrom));
            var to = _nodes.GetValueOrDefault(typeof(TTo));

            if (from == null || to == null)
            {
                Debug.LogError($"Tried to register transition between unregistered states. from:{typeof(TFrom)}, to:{typeof(TTo)}");
                return;
            }
            
            from.AddTransition(to, predicate);
        }

        public void AddAnyTransition<TTo>(IPredicate predicate)
            where TTo : IState
        {
            var to = _nodes.GetValueOrDefault(typeof(TTo));
            if (to == null)
            {
                Debug.LogError($"Tried to register transition to an unregistered states. to:{typeof(TTo)}");
                return;
            }
            
            _anyTransitions.Add(new Transition(to, predicate));
        }
        
        public void SetActiveState<T>()
            where T : IState
        {
            var node = _nodes.GetValueOrDefault(typeof(T));
            if (node == null)
            {
                Debug.LogError($"Tried to set state to an unregistered state, T:{typeof(T)}");
                return;
            }

            SetActiveState(node);
        }
        
        public void SetActiveState(StateNode node)
        {
            if (node == _current)
                return;
            
            _current?.State.OnExit();
            node.State.OnEnter();
            
            _current = node;
        }

        [CanBeNull]
        internal StateNode GetState<T>() where T : IState
        {
            return _nodes.GetValueOrDefault(typeof(T), null);
        }

        public void Update()
        {
            _current?.State.Update();
            CheckForTransition();
        }
        
        public void FixedUpdate()
        {
            _current?.State.FixedUpdate();
        }

        private void CheckForTransition()
        {
            // 1. Any transition
            var transition = _anyTransitions.FirstOrDefault(x => x.Predicate.Evaluate());
            if (transition != null && transition.To.State != _current?.State)
            {
                SetActiveState(transition.To);
                return;
            }

            // 2. Group-level transition
            var partOfGroups = _groups.Where(x => x.States.Contains(_current.State));
            foreach (var group in partOfGroups)
            {
                foreach (var groupTransition in group.Transitions)
                {
                    if (groupTransition.Predicate.Evaluate())
                    {
                        SetActiveState(groupTransition.To);
                        return;
                    }
                }
            }
            
            // 3. State-level transition
            transition = _current.Transitions.FirstOrDefault(x => x.Predicate.Evaluate());
            if (transition != null && transition.To.State != _current.State)
                SetActiveState(transition.To);
        }
    }
}