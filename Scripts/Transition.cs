using System;

namespace LemonInc.Core.StateMachine
{
    public class Transition
    {
        public StateNode To { get; private set; }
        public Func<bool> Predicate { get; private set; }

        public Transition(StateNode to, Func<bool> predicate)
        {
            To = to;
            Predicate = predicate;
        }
    }
}