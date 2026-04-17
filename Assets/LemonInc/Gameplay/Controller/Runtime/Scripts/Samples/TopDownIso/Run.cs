using LemonInc.Gameplay.Controller.Core;

namespace LemonInc.Gameplay.Controller.Samples.TopDownIso
{
    public class Run : BaseControllerState
    {
        private IsoController _c;
        protected override void OnBind() => _c = (IsoController)Controller;
        public override void FixedUpdate() => _c.HandleMovement(grounded: true);
    }
}