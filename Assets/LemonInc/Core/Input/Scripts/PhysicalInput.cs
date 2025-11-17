using System;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
    /// <summary>
    /// Represents a physical input.
    /// </summary>
    public class PhysicalInput : InputState, IUpdatableInput
    {
        /// <summary>
        /// The input action.
        /// </summary>
        private InputAction _inputAction;
        
        /// <summary>
        /// Tracks if we were pressed last frame to detect releases.
        /// </summary>
        private bool _wasPressedLastFrame;

        /// <inheritdoc/>
        public override bool PressedThisFrame => _inputAction?.WasPressedThisFrame() == true;

        /// <summary>
        /// Updates the input state. Should be called every frame.
        /// </summary>
        public void Update()
        {
            if (_inputAction == null)
                return;

            var isPressedNow = _inputAction.IsPressed();
            
            // Handle press
            if (isPressedNow && !_wasPressedLastFrame)
            {
                Hold();
            }
            // Handle release
            else if (!isPressedNow && _wasPressedLastFrame)
            {
                Release();
            }
            
            _wasPressedLastFrame = isPressedNow;
        }

        /// <summary>
        /// Subscribes the specified input action.
        /// </summary>
        /// <param name="inputAction">The input action.</param>
        public void Subscribe(InputAction inputAction)
        {
            _inputAction = inputAction;
        }

        /// <summary>
        /// Unsubscribes.
        /// </summary>
        public void UnSubscribe()
        {
            _inputAction = null;
        }
    }
}