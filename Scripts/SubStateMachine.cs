using System;
using System.Collections.Generic;
using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine
{
    public abstract class SubStateMachine : StateMachine, ISubStateMachine
    {
        private readonly List<Transition> _entryLinks = new();
        
        public new ISubStateMachine RegisterState(IState state)
        {
            Nodes.Add(state.GetType(), new StateNode(state));
            return this;
        }

        public new ISubStateMachine RegisterState<T>() where T : IState, new()
        {
            var state = new T();
            return RegisterState(state);
        }

        public void AddEntryLink<TTo>(Func<bool> condition) where TTo : IState
        {
            var to = GetNode<TTo>();
            if (to == null)
            {
                Debug.LogError($"Tried to add an entry link to and unregistered state: {typeof(TTo)}");
                return;
            }
            
            _entryLinks.Add(new Transition(to, condition));
        }
        
        private void HandleEntryLinks()
        {
            foreach (var transition in _entryLinks)
            {
                if (!transition.Predicate()) 
                    continue;
                
                SwitchToState(transition.To);
                return;
            }
        }

        public void OnEnter()
        {
            HandleEntryLinks();
            Enter();
        }

        public sealed override void Update()
        {
            base.Update();
            OnUpdate();
        }

        public sealed override void FixedUpdate()
        {
            base.FixedUpdate();
            OnFixedUpdate();
        }

        public void OnExit()
        {
            CurrentState?.OnExit();
            SwitchToState(null);
            Exit();
        }

        protected virtual void Enter() {}
        protected virtual void OnUpdate() {}
        protected virtual void OnFixedUpdate() {}
        protected virtual void Exit() {}
        
        public override string ToString()
        {
            return CurrentState switch
            {
                null => $"{GetType().Name}",
                SubStateMachine subStateMachine => $"{GetType().Name} > {subStateMachine}",
                _ => $"{GetType().Name} > {CurrentState.GetType().Name}"
            };
        }
    }
}