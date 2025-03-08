using LemonInc.Core.StateMachine;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class JumpState : StateBase
    {
        private readonly Controller _controller;

        public JumpState(GameObject owner) : base(owner)
        {
            _controller = owner.GetComponent<Controller>();
        }

        public override void OnEnter()
        {
            _controller.Jump();
        }

        public override void FixedUpdate()
        {
            _controller.HandleMovements();
        }
    }
}