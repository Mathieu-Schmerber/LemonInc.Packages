using LemonInc.Gameplay.Controller.Core;
using UnityEngine;

namespace LemonInc.Gameplay.Controller.Samples.TopDownIso
{
    public class JumpAction : BaseControllerAction
    {
        private IsoController _c;

        private float _lastJumpTime = float.MinValue;
        private float _lastGroundedTime = float.MinValue;
        private float _lastJumpPressTime = float.MinValue;

        private bool CoyoteAvailable => !_c.IsGrounded && Time.time - _lastGroundedTime <= _c.Settings.CoyoteTime;
        private bool JumpBuffered => Time.time - _lastJumpPressTime <= _c.Settings.JumpBufferTime;

        protected override void OnBind() => _c = (IsoController)Controller;

        public override bool CanExecute() =>
            IsEnabled &&
            (_c.IsGrounded || CoyoteAvailable) &&
            Time.time - _lastJumpTime >= _c.Settings.JumpCooldown;

        public override void Update()
        {
            if (_c.IsGrounded)
                _lastGroundedTime = Time.time;

            if (_c.Inputs.Jump.Pressed)
                _lastJumpPressTime = Time.time;

            if (JumpBuffered && CanExecute())
                Execute();
        }

        public override void Execute()
        {
            _lastJumpTime = Time.time;
            _lastGroundedTime = float.MinValue;
            _lastJumpPressTime = float.MinValue;

            _c.Rb.linearVelocity = new Vector3(_c.Rb.linearVelocity.x, 0f, _c.Rb.linearVelocity.z);
            _c.Rb.AddForce(Vector3.up * _c.Settings.JumpForce, ForceMode.Impulse);
        }
    }
}