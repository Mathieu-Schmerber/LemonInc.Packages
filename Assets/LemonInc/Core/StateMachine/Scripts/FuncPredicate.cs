using System;
using LemonInc.Core.StateMachine.Interfaces;

namespace LemonInc.Core.StateMachine
{
    public class FuncPredicate : IPredicate
    {
        private readonly Func<bool> _predicate;

        public FuncPredicate(Func<bool> predicate)
        {
            _predicate = predicate;
        }
        
        public bool Evaluate() => _predicate?.Invoke() ?? false;
    }
}