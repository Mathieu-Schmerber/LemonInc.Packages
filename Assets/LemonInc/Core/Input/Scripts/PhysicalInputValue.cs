using System;
using JetBrains.Annotations;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
	/// <summary>
	/// Represents a physical input.
	/// </summary>
	/// <typeparam name="TRawInput">The type that's read from the physical input like mouse and keyboard.</typeparam>
	/// <typeparam name="TConverted">The type that's consumed by the game logic.</typeparam>
	/// <seealso cref="Game.Systems.Input.InputState&lt;T&gt;" />
	public class PhysicalInputValue<TRawInput, TConverted> : InputStateValue<TConverted> 
		where TRawInput : struct
    {
		/// <summary>
		/// The input action.
		/// </summary>
		[CanBeNull] private InputAction _inputAction;

		/// <summary>
		/// The value converter.
		/// </summary>
		private readonly Func<TRawInput, TConverted> _valueConverter;

		public override TConverted Value { 
			get {
				var physicalValue = _inputAction?.ReadValue<TRawInput>() ?? new TRawInput();
				if (_valueConverter != null)
					return _valueConverter(physicalValue);
				else
				{
					if (physicalValue is TConverted value)
						return value;
					else
						throw new InvalidCastException($"Tried to convert {typeof(TRawInput).FullName} to {typeof(TConverted).FullName}, when no value convertor was assigned.");
				}
			} 
			protected set => base.Value = value; 
		}

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
			_inputAction!.performed += Performed;
			_inputAction!.canceled += Cancelled;
		}

		/// <summary>
		/// Unsubscribes.
		/// </summary>
		public void UnSubscribe()
        {
			_inputAction!.performed -= Performed;
			_inputAction!.canceled -= Cancelled;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PhysicalInputValue{U, T}"/> class.
		/// </summary>
		/// <param name="valueConverter">The value converter. If set, allows the conversion from physical value to game value.</param>
		public PhysicalInputValue(Func<TRawInput, TConverted> valueConverter = null)
        {
            _valueConverter = valueConverter;
        }
    }
}
