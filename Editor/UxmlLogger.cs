using System;
using UnityEngine;

namespace LemonInc.Editor.Uxml
{
	internal static class UxmlLogger
	{
		/// <summary>
		/// Logs the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Log(string message)
		{
			if (UxmlAssetConfiguration.Instance.DoLogTrace)
				Debug.Log(message);
		}

		/// <summary>
		/// Logs the error.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public static void LogError(Exception exception)
		{
			Debug.LogError(exception);
		}
	}
}