using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LemonInc.Core.StateMachine.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Core.StateMachine
{
    [Serializable]
    public class StateMachine : IStateMachine
    {
        protected readonly Dictionary<Type, StateNode> Nodes = new();

        [ShowInInspector, ReadOnly] private string CurrentStateName => ToString();
        
        public IState CurrentState => Current?.State;

        [CanBeNull] protected StateNode Current;

        [CanBeNull] protected StateNode GetNode<T>() 
            where T : IState
            => Nodes.GetValueOrDefault(typeof(T), null);

        [CanBeNull] protected StateNode GetNode(Type type)
            => Nodes.GetValueOrDefault(type, null);
        
        public IState GetState<T>() 
            where T : IState 
            => GetNode<T>()?.State;
        
        public ISubStateMachine GetSubStateMachine<T>() 
            where T : ISubStateMachine
            => GetState<T>() as ISubStateMachine;

        public ISubStateMachine RegisterSubStateMachine(ISubStateMachine subStateMachine)
        {
            Nodes[subStateMachine.GetType()] = new StateNode(subStateMachine);
            return subStateMachine;
        }

        public ISubStateMachine RegisterSubStateMachine<T>() 
            where T : ISubStateMachine, new()
        {
            var state = new T();
            return RegisterSubStateMachine(state);
        }

        public IStateMachine RegisterState(IState state)
        {
            Nodes.Add(state.GetType(), new StateNode(state));
            return this;
        }

        public IStateMachine RegisterState<T>() 
            where T : IState, new()
        {
            var state = new T();
            return RegisterState(state);
        }

        public void AddLink<TFrom, TTo>(Func<bool> condition) where TFrom : IState where TTo : IState
        {
            var from = GetNode<TFrom>();
            if (from == null)
            {
                Debug.LogError($"Tried to add a link from an unregistered state: {typeof(TFrom).Name}");
                return;
            }
            
            var to = GetNode<TTo>();
            if (to == null)
            {
                Debug.LogError($"Tried to add a link to an unregistered state: {typeof(TTo).Name}");
                return;
            }
            
            from.AddTransition(to, condition);
        }

        public void AddMutualLink<TFrom, TTo>(Func<bool> condition) where TFrom : IState where TTo : IState
        {
            AddLink<TFrom, TTo>(condition);
            AddLink<TTo, TFrom>(() => !condition.Invoke());
        }

        public void SetActiveState<T>() where T : IState
        {
            var stateNode = GetNode<T>();
            if (stateNode == null)
            {
                Debug.LogError($"Tried to set an unregistered state to active: {typeof(T).Name}");
                return;
            }
            
            Current = stateNode;
        }
        
        public void SetActiveState(IState state)
        {
            var stateNode = GetNode(state.GetType());
            if (stateNode == null)
            {
                Debug.LogError($"Tried to set an unregistered state to active: {state.GetType().Name}");
                return;
            }
            
            Current = stateNode;
        }

        public virtual void Update()
        {
            HandleTransitions();
            CurrentState?.Update();
        }

        public virtual void FixedUpdate() => CurrentState?.FixedUpdate();

        protected void SwitchToState(StateNode node)
        {
            if (Equals(Current, node))
                return;
            
            Current?.State.OnExit();
            Current = node;
            Current?.State.OnEnter();
        }
        
        private void HandleTransitions()
        {
            if (Current == null)
                return;
            
            foreach (var transition in Current.Transitions)
            {
                if (!transition.Predicate())
                    continue;

                SwitchToState(transition.To);
                return;
            }
        }
        
        public override string ToString()
        {
            return CurrentState switch
            {
                null => "StateMachine",
                SubStateMachine subStateMachine => $"StateMachine > {subStateMachine}",
                _ => $"StateMachine > {CurrentState.GetType().Name}"
            };
        }
    }
}