using LemonInc.Core.StateMachine.FSM;
using LemonInc.Test.StateDemo.Scripts.Inputs;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class Grounded : SubStateMachine
    {
        private readonly Controller _controller;
        private readonly IInputProvider _inputs;

        public Grounded(Transform owner)
        {
            _controller = owner.gameObject.GetComponent<Controller>();
            _inputs = owner.gameObject.GetComponent<IInputProvider>();
        }
    }
}