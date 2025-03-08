using LemonInc.Core.Input;
using LemonInc.Core.Utilities.Extensions;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.Inputs
{
    public class PlayerInputProvider : InputProviderBase<Controls>, IInputProvider
    {
        private readonly PhysicalInputValue<Vector2, Vector3> _movement = new(x => x.ToVector3Xz().ToIsometric().normalized);
        private readonly PhysicalInput _jump = new();

        public InputStateValue<Vector3> Movement => _movement;
        public InputState Jump => _jump;

        protected override void SubscribeInputs()
        {
            _jump.Subscribe(Controls.Player.Jump);
            _movement.Subscribe(Controls.Player.Movement);
        }

        protected override void UnSubscribeInputs()
        {
            _jump.UnSubscribe();
            _movement.UnSubscribe();
        }
    }
}