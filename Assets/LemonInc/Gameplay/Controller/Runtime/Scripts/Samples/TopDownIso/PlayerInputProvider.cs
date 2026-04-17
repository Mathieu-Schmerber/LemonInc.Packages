using LemonInc.Core.Input;
using LemonInc.Core.Utilities.Extensions;
using UnityEngine;

namespace LemonInc.Gameplay.Controller.Samples.TopDownIso
{
    public class PlayerInputProvider : InputProviderBase<Controls>, IInputProvider
    {
        [Input] private readonly PhysicalInputValue<Vector2, Vector3> _movement = new(x => x.ToVector3Xz().ToIsometric().normalized);
        [Input] private readonly PhysicalInput _jump = new();
        [Input] private readonly GestureInput _gesture = new();

        public InputStateValue<Vector3> Movement => _movement;
        public InputState Jump => _jump;
        public InputState Right => _gesture.SwipeRight;
        public InputState Left => _gesture.SwipeLeft;

        protected override void SubscribeInputs()
        {
            _jump.Subscribe(Controls.Player.Jump);
            _movement.Subscribe(Controls.Player.Movement);
            _gesture.Subscribe(Controls.Player.PrimaryContact, Controls.Player.PrimaryPosition);
        }
    }
}