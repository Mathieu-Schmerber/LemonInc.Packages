using System;

namespace LemonInc.Core.StateMachine.Interfaces
{
    public interface ISubStateMachine : IStateMachine, IState
    {
        public new ISubStateMachine RegisterState(IState state);
        public new ISubStateMachine RegisterState<T>()
            where T : IState, new();
        
        public void AddEntryLink<TTo>(Func<bool> condition) 
            where TTo : IState;
    }
}