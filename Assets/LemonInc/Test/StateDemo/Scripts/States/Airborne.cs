using LemonInc.Core.StateMachine;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class Airborne : SubStateMachine
    {
        private readonly Rigidbody _rb;
        private readonly Controller _controller;

        public bool IsFalling => _rb.linearVelocity.y < 0;
        
        public Airborne(Transform owner)
        {
            _controller = owner.GetComponent<Controller>();
            _rb = owner.GetComponent<Rigidbody>();
            
            RegisterState(new Falling(owner));
            RegisterState(new Jump(owner));
            
            AddEntryLink<Falling>(() => IsFalling);
            AddEntryLink<Jump>(() => !IsFalling);
            AddLink<Jump, Falling>(() => IsFalling);
        }

        protected override void OnFixedUpdate() => _controller.HandleMovements();
    }
}