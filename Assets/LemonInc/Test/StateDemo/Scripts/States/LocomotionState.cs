using LemonInc.Core.StateMachine;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class LocomotionState : StateBase
    {
        private readonly Controller _controller;

        public LocomotionState(GameObject owner) : base(owner)
        {
            _controller = owner.GetComponent<Controller>();
        }

        public override void FixedUpdate()
        {
            _controller.HandleMovements();
        }
    }
}