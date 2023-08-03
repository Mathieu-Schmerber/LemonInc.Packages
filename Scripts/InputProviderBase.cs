using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
	/// <summary>
	/// Input provider.
	/// </summary>
	[RequireComponent(typeof(PlayerInput))]
	public abstract class InputProviderBase : MonoBehaviour, IInputProvider
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
		/// Gets the input state.
		/// </summary>
		/// <param name="state">Initial state.</param>
		/// <returns>
		/// The state.
		/// </returns>
		public abstract object GetInput(object state);
		
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
		}

		/// <summary>
		/// Called when [disable].
		/// </summary>
		protected virtual void OnDisable()
		{
			if (_playerInput != null)
				_playerInput.onControlsChanged -= OnControlsChanged;
		}

		private void OnControlsChanged(PlayerInput input)
		{
			if (input.devices[0].device.displayName.Contains("Keyboard"))
				InUseControlType = ControlType.KEYBOARD;
			else if (Gamepad.current is UnityEngine.InputSystem.XInput.XInputController) // XBOX
				InUseControlType = ControlType.XBOX;
			else if (Gamepad.current is UnityEngine.InputSystem.DualShock.DualShockGamepad) // PS4
				InUseControlType = ControlType.PS4;
			OnControlsChangedEvent?.Invoke(InUseControlType);
		}

		/// <summary>
		/// Waits the and execute.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <param name="execute">The execute.</param>
		private static async void WaitAndExecute(float time, Action execute)
		{
			float start = Time.time;
			float end = start + time;

			while (Time.time < end)
				await Task.Yield();
			execute.Invoke();
		}

		/// <summary>
		/// Vibrates the controller.
		/// </summary>
		/// <param name="normalizedAmount">The normalized amount.</param>
		/// <param name="time">The time.</param>
		public static void VibrateController(float normalizedAmount, float time)
		{
			if (time == 0 || normalizedAmount == 0 || Gamepad.current == null)
				return;
			Gamepad.current.SetMotorSpeeds(normalizedAmount, normalizedAmount);
			WaitAndExecute(time, () => Gamepad.current.SetMotorSpeeds(0, 0));
		}
	}
}