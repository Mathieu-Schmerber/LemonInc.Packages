using LemonInc.Core.Input;
using LemonInc.Core.Utilities.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LemonInc.Test.StateDemo.Scripts.Inputs
{
    public class PlayerInputProvider : InputProviderBase<Controls>, IInputProvider
    {
        private readonly PhysicalInputValue<Vector2, Vector3> _movement = new(x => x.ToVector3Xz().ToIsometric().normalized);
        private readonly PhysicalInput _jump = new();
        private readonly TouchInput _touch = new();

        public InputStateValue<Vector3> Movement => _movement;
        public InputState Jump => _jump;
        public InputState Right => _touch.SwipeRight;
        public InputState Left => _touch.SwipeLeft;

        protected override void SubscribeInputs()
        {
            _jump.Subscribe(Controls.Player.Jump);
            _movement.Subscribe(Controls.Player.Movement);
            _touch.Subscribe(Controls.Player.PrimaryContact, Controls.Player.PrimaryPosition);
        }

        protected override void UnSubscribeInputs()
        {
            _jump.UnSubscribe();
            _movement.UnSubscribe();
            _touch.UnSubscribe();
        }
    }
}