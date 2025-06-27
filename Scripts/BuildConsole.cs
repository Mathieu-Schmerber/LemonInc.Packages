using System;
using System.IO;
using UnityEngine;

namespace LemonInc.Core.Utilities
{
	public class BuildConsole : MonoBehaviour
	{
		[SerializeField] private float _windowX = 10f;
		[SerializeField] private float _windowY = 10f;
		[SerializeField] private float _windowWidth = 400f;
		[SerializeField] private float _windowHeight = 300f;

		private string _logs;
		private Vector2 _scrollPosition;
		private string _logFilePath;

		private void Start()
		{
			// Get the path to the directory where the executable is located
			string executableDirectory = Path.GetDirectoryName(Application.dataPath);

			// Specify the path for the log file (next to the executable)
			_logFilePath = Path.Combine(executableDirectory, "application_log.txt");

			// If the log file exists, delete it to clear previous logs
			if (File.Exists(_logFilePath))
			{
				File.Delete(_logFilePath);
			}
		}

		private void OnEnable()
		{
			Application.logMessageReceived += HandleLog;
		}

		private void OnDisable()
		{
			Application.logMessageReceived -= HandleLog;
		}

		private void HandleLog(string logText, string stackTrace, LogType type)
		{
			// Append the new log message to the logs string
			_logs += $"[{DateTime.Now.ToShortTimeString()}]" + logText + "\n";

			// Write the log message to the log file
			using (StreamWriter writer = new StreamWriter(_logFilePath, true))
			{
				writer.WriteLine(logText);
			}

			// Make sure the scroll position is always at the bottom to display latest logs
			_scrollPosition.y = Mathf.Infinity;
		}

		private void OnGUI()
		{
			// Set the position and size of the log window
			Rect logWindowRect = new Rect(_windowX, _windowY, _windowWidth, _windowHeight);

			// Begin the log window GUI group
			GUI.BeginGroup(logWindowRect);

			// Create a scroll view for the logs
			_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(_windowWidth), GUILayout.Height(_windowHeight));

			// Draw the console GUI
			GUILayout.TextArea(_logs);

			// End the scroll view
			GUILayout.EndScrollView();

			// End the log window GUI group
			GUI.EndGroup();
		}
	}
}
