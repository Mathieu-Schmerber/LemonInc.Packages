using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Utilities.Editor.Helpers;
using LemonInc.Core.Utilities.Editor.SearchWindows;
using LemonInc.Editor.Toolbar;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LemonInc.Tools.SceneSwitcher.Editor
{
	/// <summary>
	/// Scene switcher button.
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	[InitializeOnLoad]
	public class SceneSwitcherButton : MonoBehaviour
	{
		/// <summary>
		/// Initializes the <see cref="SceneSwitcherButton"/> class.
		/// </summary>
		static SceneSwitcherButton()
		{
			ToolbarExtender.LeftToolbarGui.Add(OnToolbarGUI);
		}

		/// <summary>
		/// Called when [toolbar GUI].
		/// </summary>
		private static void OnToolbarGUI()
		{
			if (Application.isPlaying)
				return;

			GUILayout.FlexibleSpace();
			var pressed = GUILayout.Button($"{SceneManager.GetActiveScene().name}", EditorStyles.layerMaskField,
				GUILayout.Width(200), GUILayout.Height(35));

			if (pressed)
				SceneSwitcherWindow.Open();
		}
	}
}