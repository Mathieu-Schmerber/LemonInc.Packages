using UnityEngine;

namespace LemonInc.Core.Utilities
{
	/// <summary>
	/// https://answers.unity.com/questions/125049/is-there-any-way-to-view-the-console-in-a-build.html
	/// </summary>
	public class BuildConsole : MonoBehaviour
	{
		private string _logStart = "*** Logs ***";
		private string _filename = "";

		private const int KChars = 700;

		[SerializeField] private const bool Show = true;

		private void OnEnable() { Application.logMessageReceived += Log; }
		private void OnDisable() { Application.logMessageReceived -= Log; }

		public void Log(string logString, string stackTrace, LogType type)
		{
			_logStart = _logStart + "\n" + logString;

			if (_logStart.Length > KChars)
				_logStart = _logStart.Substring(_logStart.Length - KChars);

			if (string.IsNullOrEmpty(_filename))
			{
				var d = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/LOGS";
				System.IO.Directory.CreateDirectory(d);
				var r = Random.Range(1000, 9999).ToString();
				_filename = d + "/log-" + r + ".txt";
			}

			try
			{
				System.IO.File.AppendAllText(_filename, logString + "\n");
			}
			catch
			{
				// ignored
			}
		}

		private void OnGUI()
		{
			if (!Show) { return; }
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
			   new Vector3(Screen.width / 1200.0f, Screen.height / 800.0f, 1.0f));
			GUI.TextArea(new Rect(10, 10, 540, 370), _logStart);
		}
	}
}
