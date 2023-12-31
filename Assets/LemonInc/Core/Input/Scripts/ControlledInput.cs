﻿using System;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
	/// <summary>
	/// Manages a controlled input with press events.
	/// </summary>
	public class ControlledInput
	{
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ControlledInput"/> is pressed.
		/// </summary>
		/// <value>
		///   <c>true</c> if pressed; otherwise, <c>false</c>.
		/// </value>
		public bool Pressed { get; private set; }

		/// <summary>
		/// Occurs when [on pressed].
		/// </summary>
		public event Action OnPressed;

		/// <summary>
		/// Occurs when [on released].
		/// </summary>
		public event Action OnReleased;

		/// <summary>
		/// The input action.
		/// </summary>
		private readonly InputAction _inputAction;

		/// <summary>
		/// Subscribes this instance.
		/// </summary>
		public void Subscribe()
		{
			_inputAction.performed += Performed;
			_inputAction.canceled += Canceled;
		}

		/// <summary>
		/// Unsubscribes this instance.
		/// </summary>
		public void Unsubscribe()
		{
			_inputAction.performed -= Performed;
			_inputAction.canceled -= Canceled;
		}
		
		private void Performed(InputAction.CallbackContext obj)
		{
			Pressed = true;
			OnPressed?.Invoke();
		}

		private void Canceled(InputAction.CallbackContext obj)
		{
			Pressed = false;
			OnReleased?.Invoke();
		}

		/// <summary>
		/// Subscribes the specified input action.
		/// </summary>
		/// <param name="inputAction">The input action.</param>
		/// <param name="controlledInput">The controlled input.</param>
		/// <returns></returns>
		public static ControlledInput Subscribe(InputAction inputAction, ControlledInput controlledInput = null)
		{
			if (controlledInput != null)
			{
				controlledInput.Unsubscribe();
				controlledInput.Subscribe();
				return controlledInput;
			}

			var instance = new ControlledInput(inputAction);
			instance.Subscribe();
			return instance;
		}

			/// <summary>
		/// Initializes a new instance of the <see cref="ControlledInput"/> struct.
		/// </summary>
		/// <param name="inputAction">The input action.</param>
		private ControlledInput(InputAction inputAction)
		{
			_inputAction = inputAction;
			Pressed = false;
			OnPressed = null;
			OnReleased = null;
		}
	}
}