using System;
using JetBrains.Annotations;

namespace LemonInc.Core.StateMachine.Interfaces
{
    public interface IStateMachine
    {
        [CanBeNull] IState CurrentState { get; }
        [CanBeNull] IState GetState<T>() where T : IState;
        [CanBeNull] IState SearchStateRecursively<T>() where T : IState;
        [CanBeNull] ISubStateMachine GetSubStateMachine<T>() where T : ISubStateMachine;
        
        ISubStateMachine RegisterSubStateMachine(ISubStateMachine subStateMachine);
        ISubStateMachine RegisterSubStateMachine<T>() 
            where T : ISubStateMachine, new();
        
        IStateMachine RegisterState(IState state);
        IStateMachine RegisterState<T>()
            where T : IState, new();
        
        void AddLink<TFrom, TTo>(Func<bool> condition) 
            where TFrom : IState
            where TTo : IState;
        void AddMutualLink<TFrom, TTo>(Func<bool> condition) 
            where TFrom : IState
            where TTo : IState;
        
        void SetActiveState(IState state);
        void SetActiveState<T>() where T : IState;

        void Update();
        void FixedUpdate();
    }
}