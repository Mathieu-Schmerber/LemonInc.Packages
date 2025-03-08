using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine
{
    public class StateMachine
    {
        private readonly List<Transition> _anyTransitions = new();
        private readonly Dictionary<Type, StateNode> _nodes = new();
        private StateNode _current;

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
            var transition = _anyTransitions.FirstOrDefault(x => x.Predicate.Evaluate());
            if (transition != null)
            {
                SetActiveState(transition.To);
                return;
            }
            
            transition = _current.Transitions.FirstOrDefault(x => x.Predicate.Evaluate());
            if (transition != null)
                SetActiveState(transition.To);
        }

        
    }
}