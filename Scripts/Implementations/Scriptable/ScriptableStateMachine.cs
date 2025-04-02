using System;
using LemonInc.Core.StateMachine.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Implementations.Scriptable
{
    public class ScriptableStateMachine : ScriptableObject, IStateMachine
    {
        [SerializeField, InlineProperty] private StateMachine _stateMachine = new();
        
        public IState CurrentState => _stateMachine.CurrentState;

        public IState GetState<T>() where T : IState 
            => _stateMachine.GetState<T>();

        public ISubStateMachine GetSubStateMachine<T>() where T : ISubStateMachine 
            => _stateMachine.GetSubStateMachine<T>();

        public ISubStateMachine RegisterSubStateMachine(ISubStateMachine subStateMachine) 
            => _stateMachine.RegisterSubStateMachine(subStateMachine);

        public ISubStateMachine RegisterSubStateMachine<T>() where T : ISubStateMachine, new() 
            => _stateMachine.RegisterSubStateMachine<T>();

        public IStateMachine RegisterState(IState state)
        {
            _stateMachine.RegisterState(state);
            return this;
        }

        public IStateMachine RegisterState<T>() where T : IState, new()
        {
            _stateMachine.RegisterState<T>();
            return this;
        }

        public void AddLink<TFrom, TTo>(Func<bool> condition) where TFrom : IState where TTo : IState 
            => _stateMachine.AddLink<TFrom, TTo>(condition);

        public void AddMutualLink<TFrom, TTo>(Func<bool> condition) where TFrom : IState where TTo : IState 
            => _stateMachine.AddMutualLink<TFrom, TTo>(condition);

        public void SetActiveState(IState state) 
            => _stateMachine.SetActiveState(state);

        public void SetActiveState<T>() where T : IState 
            => _stateMachine.SetActiveState<T>();

        public void Update() 
            => _stateMachine.Update();

        public void FixedUpdate() 
            => _stateMachine.FixedUpdate();
        
        public override string ToString()
        {
            return CurrentState switch
            {
                null => $"{GetType().Name}",
                ISubStateMachine subStateMachine => $"{GetType().Name} > {subStateMachine}",
                _ => $"{GetType().Name} > {CurrentState.GetType().Name}"
            };
        }
    }
}