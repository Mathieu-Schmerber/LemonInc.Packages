using System.Collections.Generic;
using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine
{
    public class StateGroup
    {
        private readonly StateMachine _stateMachine;
        private readonly List<Transition> _transitions;
        
        public IState[] States { get; private set; }
        public IReadOnlyList<Transition> Transitions => _transitions;

        public StateGroup(StateMachine stateMachine, params IState[] states)
        {
            _stateMachine = stateMachine;
            States = states;
            _transitions = new List<Transition>();
        }

        public void AddTransition<TTo>(IPredicate predicate) where TTo : IState
        {
            var state = _stateMachine.GetState<TTo>();
            if (state == null)
            {
                Debug.LogError($"Tried to add transition to an unregistered state, T:{typeof(TTo)}");
                return;
            }
            
            AddTransition(state, predicate);
        }
        
        public void AddTransition(StateNode toState, IPredicate predicate)
        {
            var transition = new Transition(toState, predicate);
            _transitions.Add(transition);
        }
    }
}