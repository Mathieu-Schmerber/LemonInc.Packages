using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace LemonInc.Core.Utilities
{
	/// <summary>
	/// Awaiter utilities.
	/// </summary>
	public static class Awaiter
	{
		/// <summary>
		/// Waits then execute the given action.
		/// </summary>
		/// <param name="time">The time to wait in seconds.</param>
		/// <param name="execute">The action callback.</param>
		/// <param name="useTimeScale">Will depend on the time scale if true.</param>
		public static async void WaitAndExecute(float time, Action execute, bool useTimeScale = true)
		{
			float start;
			float end;

			if (useTimeScale)
			{
				start = Time.time;
				end = start + time;

				while (Time.time < end)
					await Task.Yield();
			}
			else
			{
				start = Time.unscaledTime;
				end = start + time;

				while (Time.unscaledTime < end)
					await Task.Yield();
			}

			execute.Invoke();
		}

		/// <summary>
		/// Executes an action then waits.
		/// </summary>
		/// <param name="time">The time to wait in seconds.</param>
		/// <param name="execute">The action callback.</param>
		/// <param name="useTimeScale">Will depend on the time scale if true.</param>
		public static async Task ExecuteAndWait(float time, Action execute, bool useTimeScale = true)
		{
			float start;
			float end;

			execute.Invoke();

			if (useTimeScale)
			{
				start = Time.time;
				end = start + time;

				while (Time.time < end)
					await Task.Yield();
			}
			else
			{
				start = Time.unscaledTime;
				end = start + time;

				while (Time.unscaledTime < end)
					await Task.Yield();
			}
		}

		public enum WaitUntilResult
		{
			Completed,
			TimedOut,
			Canceled
		}

		/// <summary>
		/// Waits until the given predicates is validated and execute an action.
		/// </summary>
		/// <param name="predicate">The predicate to wait for</param>
		/// <param name="callback">The callback to execute.</param>
		/// <param name="timeout">The timeout in seconds.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static async Task WaitUntilTrue(
			Func<bool> predicate,
			Action<WaitUntilResult> callback,
			float timeout,
			CancellationToken cancellationToken = default)
		{
			var startTime = Time.time;
			var reason = WaitUntilResult.Completed;
			
			while (!predicate.Invoke())
			{
				if (cancellationToken.IsCancellationRequested)
				{
					reason = (WaitUntilResult.Canceled);
					break;
				}
				
				if (Time.time - startTime >= timeout)
				{
					reason = (WaitUntilResult.TimedOut);
					return;
				}
				
				await Task.Yield();
			}
    
			callback.Invoke(reason);
		}
	}
}
