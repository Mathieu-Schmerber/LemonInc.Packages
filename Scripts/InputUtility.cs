using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
	/// <summary>
	/// Input utilities.
	/// </summary>
	public static class InputUtility 
	{
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