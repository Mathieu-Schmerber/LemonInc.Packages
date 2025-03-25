using System;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
    /// <summary>
    /// Represents a physical input.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Game.Systems.Input.InputState&lt;T&gt;" />
    public class PhysicalInput : InputState
    {
        /// <summary>
		/// The input action.
		/// </summary>
		private InputAction _inputAction;

        /// <inheritdoc/>
        public override bool PressedThisFrame => _inputAction?.WasPressedThisFrame() == true;

        /// <summary>
        /// Performs the specified input.
        /// </summary>
        /// <param name="ctx">The context.</param>
        private void Performed(InputAction.CallbackContext ctx) => Hold();

        /// <summary>
        /// Cancels the specified input.
        /// </summary>
        /// <param name="_">The context</param>
        private void Cancelled(InputAction.CallbackContext _) => Release();

        /// <summary>
        /// Subscribes the specified input action.
        /// </summary>
        /// <param name="inputAction">The input action.</param>
        public void Subscribe(InputAction inputAction)
        {
            _inputAction = inputAction;
            _inputAction.performed += Performed;
            _inputAction.canceled += Cancelled;
        }

        /// <summary>
        /// Unsubscribes.
        /// </summary>
        public void UnSubscribe()
        {
            _inputAction.performed -= Performed;
            _inputAction.canceled -= Cancelled;
        }
    }
}
