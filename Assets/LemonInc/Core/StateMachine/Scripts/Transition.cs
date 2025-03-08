using LemonInc.Core.StateMachine.Interfaces;

namespace LemonInc.Core.StateMachine
{
    public class Transition
    {
        public StateNode To { get; private set; }
        public IPredicate Predicate { get; private set; }

        public Transition(StateNode to, IPredicate predicate)
        {
            To = to;
            Predicate = predicate;
        }
    }
}