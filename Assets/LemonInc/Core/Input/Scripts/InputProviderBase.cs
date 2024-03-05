using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
	/// <summary>
	/// Input provider.
	/// </summary>
	public abstract class InputProviderBase<T> : MonoBehaviour
		where T : IInputActionCollection, new()
	{
		/// <summary>
		/// Control types.
		/// </summary>
		public enum ControlType
		{
			XBOX,
			PS4,
			KEYBOARD
		}

		/// <summary>
		/// Gets the type of the in use control.
		/// </summary>
		/// <value>
		/// The type of the in use control.
		/// </value>
		public ControlType InUseControlType { get; private set; }
		
		/// <summary>
		/// The player input.
		/// </summary>
		protected PlayerInput _playerInput;
		
		/// <summary>
		/// Occurs when [on controls changed event].
		/// </summary>
		public event Action<ControlType> OnControlsChangedEvent;

		/// <summary>
		/// The controls asset.
		/// </summary>
		private T _controls;

		/// <summary>
		/// The controls asset.
		/// </summary>
		public T Controls => _controls ??= new T();

		/// <summary>
		/// Awakes this instance.
		/// </summary>
		protected virtual void Awake()
		{
			_playerInput = GetComponent<PlayerInput>();
		}

		/// <summary>
		/// Called when [enable].
		/// </summary>
		protected virtual void OnEnable()
		{
			if (_playerInput != null)
				_playerInput.onControlsChanged += OnControlsChanged;

			Controls.Enable();
			SubscribeInputs();
		}

		/// <summary>
		/// Called when [disable].
		/// </summary>
		protected virtual void OnDisable()
		{
			if (_playerInput != null)
				_playerInput.onControlsChanged -= OnControlsChanged;

			Controls.Disable();
			UnSubscribeInputs();
		}

		protected abstract void SubscribeInputs();
		protected abstract void UnSubscribeInputs();

		/// <summary>
		/// Called when [controls changed].
		/// </summary>
		/// <param name="input">The input.</param>
		private void OnControlsChanged(PlayerInput input)
		{
			if (!input.devices.Any())
				return;

			if (input.devices[0].device.displayName.Contains("Keyboard"))
				InUseControlType = ControlType.KEYBOARD;
			else if (Gamepad.current is UnityEngine.InputSystem.XInput.XInputController) // XBOX
				InUseControlType = ControlType.XBOX;
			else if (Gamepad.current is UnityEngine.InputSystem.DualShock.DualShockGamepad) // PS4
				InUseControlType = ControlType.PS4;
			OnControlsChangedEvent?.Invoke(InUseControlType);
		}
	}
}