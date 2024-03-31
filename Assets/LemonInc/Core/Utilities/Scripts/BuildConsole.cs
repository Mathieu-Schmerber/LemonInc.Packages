using System;
using System.IO;
using UnityEngine;

namespace LemonInc.Core.Utilities
{
	public class BuildConsole : MonoBehaviour
	{
		[SerializeField] private float windowX = 10f;
		[SerializeField] private float windowY = 10f;
		[SerializeField] private float windowWidth = 400f;
		[SerializeField] private float windowHeight = 300f;

		private string logs;
		private Vector2 scrollPosition;
		private string logFilePath;

		private void Start()
		{
			// Get the path to the directory where the executable is located
			string executableDirectory = Path.GetDirectoryName(Application.dataPath);

			// Specify the path for the log file (next to the executable)
			logFilePath = Path.Combine(executableDirectory, "application_log.txt");

			// If the log file exists, delete it to clear previous logs
			if (File.Exists(logFilePath))
			{
				File.Delete(logFilePath);
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
			logs += $"[{DateTime.Now.ToShortTimeString()}]" + logText + "\n";

			// Write the log message to the log file
			using (StreamWriter writer = new StreamWriter(logFilePath, true))
			{
				writer.WriteLine(logText);
			}

			// Make sure the scroll position is always at the bottom to display latest logs
			scrollPosition.y = Mathf.Infinity;
		}

		private void OnGUI()
		{
			// Set the position and size of the log window
			Rect logWindowRect = new Rect(windowX, windowY, windowWidth, windowHeight);

			// Begin the log window GUI group
			GUI.BeginGroup(logWindowRect);

			// Create a scroll view for the logs
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(windowWidth), GUILayout.Height(windowHeight));

			// Draw the console GUI
			GUILayout.TextArea(logs);

			// End the scroll view
			GUILayout.EndScrollView();

			// End the log window GUI group
			GUI.EndGroup();
		}
	}
}
