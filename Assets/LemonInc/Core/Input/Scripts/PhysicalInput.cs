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
        /// Performs the specified input.
        /// </summary>
        /// <param name="_">The context.</param>
        private void Performed(InputAction.CallbackContext _) => Hold();

        /// <summary>
        /// Cancels the specified input.
        /// </summary>
        /// <param name="_">The context</param>
        private void Cancelled(InputAction.CallbackContext _) => Release();

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlledInput"/> struct.
        /// </summary>
        /// <param name="inputAction">The input action.</param>
        public PhysicalInput(InputAction inputAction)
        {
            inputAction.performed += Performed;
            inputAction.canceled += Cancelled;
        }
    }
}
