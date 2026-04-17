using System;
using LemonInc.Gameplay.Controller.Core;

namespace LemonInc.Gameplay.Controller.Samples.TopDownIso
{
    public class Grounded : BaseControllerSubStateMachine
    {
        private IsoController _c;
 
        // Only Jump is permitted while grounded
        protected override Type[] AllowedActions => new[] { typeof(JumpAction) };
 
        protected override void OnBind()
        {
            _c = (IsoController)Controller;
 
            RegisterBoundState<Idle>();
            RegisterBoundState<Run>();
 
            AddEntryLink<Idle>(() => !_c.IsMoving);
            AddEntryLink<Run>(() => _c.IsMoving);
            AddMutualLink<Idle, Run>(() => _c.IsMoving);
        }
    }
}