using System;
using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Implementations.Scriptable
{
    public abstract class ScriptableSubStateMachine : ScriptableObject, ISubStateMachine
    {
        private class SubStateMachine_Impl : SubStateMachine {}
        
        private readonly SubStateMachine_Impl _subStateMachine = new();

        public IState CurrentState => _subStateMachine.CurrentState;

        public IState GetState<T>() where T : IState
            => _subStateMachine.GetState<T>();

        public ISubStateMachine GetSubStateMachine<T>() where T : ISubStateMachine
            => _subStateMachine.GetSubStateMachine<T>();

        public ISubStateMachine RegisterSubStateMachine(ISubStateMachine subStateMachine)
            => _subStateMachine.RegisterSubStateMachine(subStateMachine);

        public ISubStateMachine RegisterSubStateMachine<T>() where T : ISubStateMachine, new()
            => _subStateMachine.RegisterSubStateMachine<T>();

        public ISubStateMachine RegisterState(IState state)
            => _subStateMachine.RegisterState(state);

        public ISubStateMachine RegisterState<T>() where T : IState, new()
            => _subStateMachine.RegisterState<T>();

        public void AddEntryLink<TTo>(Func<bool> condition) where TTo : IState
            => _subStateMachine.AddEntryLink<TTo>(condition);

        IStateMachine IStateMachine.RegisterState(IState state)
            => _subStateMachine.RegisterState(state);

        IStateMachine IStateMachine.RegisterState<T>()
            => _subStateMachine.RegisterState<T>();

        public void AddLink<TFrom, TTo>(Func<bool> condition) where TFrom : IState where TTo : IState
            => _subStateMachine.AddLink<TFrom, TTo>(condition);

        public void AddMutualLink<TFrom, TTo>(Func<bool> condition) where TFrom : IState where TTo : IState
            => _subStateMachine.AddMutualLink<TFrom, TTo>(condition);

        public void SetActiveState(IState state)
            => _subStateMachine.SetActiveState(state);

        public void SetActiveState<T>() where T : IState
            => _subStateMachine.SetActiveState<T>();

        public void OnEnter()
        {
            _subStateMachine.OnEnter();
            Enter();
        }

        void IState.Update()
        {
            _subStateMachine.Update();
            OnUpdate();
        }

        void IState.FixedUpdate()
        {
            _subStateMachine.FixedUpdate();
            OnFixedUpdate();
        }

        public void OnExit()
        {
            _subStateMachine.OnExit();
            Exit();
        }

        void IStateMachine.Update()
            => _subStateMachine.Update();

        void IStateMachine.FixedUpdate()
            => _subStateMachine.FixedUpdate();
        
        protected virtual void Enter() {}
        protected virtual void OnUpdate() {}
        protected virtual void OnFixedUpdate() {}
        protected virtual void Exit() {}
        
        public override string ToString() => _subStateMachine.ToString();
    }
}