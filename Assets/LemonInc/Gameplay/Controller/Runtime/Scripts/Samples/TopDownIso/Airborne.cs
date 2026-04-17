using System;
using LemonInc.Gameplay.Controller.Core;

namespace LemonInc.Gameplay.Controller.Samples.TopDownIso
{
    public class Airborne : BaseControllerSubStateMachine
    {
        private IsoController _c;
 
        // No actions permitted while airborne
        protected override Type[] AllowedActions => Array.Empty<Type>();
 
        private bool IsFalling => _c.Rb.linearVelocity.y < 0;
 
        protected override void OnBind()
        {
            _c = (IsoController)Controller;
 
            RegisterBoundState<Falling>();
            RegisterBoundState<JumpState>();
 
            AddEntryLink<Falling>(() => IsFalling);
            AddEntryLink<JumpState>(() => !IsFalling);
            AddLink<JumpState, Falling>(() => IsFalling);
        }
 
        protected override void OnFixedUpdate() => _c.HandleMovement(grounded: false);
    }
}