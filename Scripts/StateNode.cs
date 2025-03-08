using System.Collections.Generic;
using LemonInc.Core.StateMachine.Interfaces;

namespace LemonInc.Core.StateMachine
{
    public class StateNode
    {
        private List<Transition> _transitions;
        
        public IState State { get; private set; }
        public IReadOnlyList<Transition> Transitions => _transitions;

        public StateNode(IState state)
        {
            State = state;
            _transitions = new List<Transition>();
        }

        public void AddTransition(StateNode toState, IPredicate predicate)
        {
            var transition = new Transition(toState, predicate);
            _transitions.Add(transition);
        }
    }
}