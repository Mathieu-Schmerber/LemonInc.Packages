using System;

namespace LemonInc.Core.Input
{
	/// <summary>
	/// Describes an input.
	/// </summary>
	public class InputState
	{
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="InputState"/> is pressed.
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
		/// Hold this input.
		/// </summary>
		public void Hold()
		{
			Pressed = true;
			OnPressed?.Invoke();
		}

		/// <summary>
		/// Presses then releases this input.
		/// </summary>
		public void Press()
		{
			Hold();
			Release();
		}

		/// <summary>
		/// Releases this input.
		/// </summary>
		public void Release()
		{
			Pressed = false;
			OnReleased?.Invoke();
		}
    }
}
