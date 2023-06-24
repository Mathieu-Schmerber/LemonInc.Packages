using LemonInc.Editor.Toolbar;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace LemonInc.Editor.SceneSwitcher
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
			bool pressed = GUILayout.Button($"{EditorSceneManager.GetActiveScene().name}", EditorStyles.layerMaskField,
				GUILayout.Width(200), GUILayout.Height(25));

			if (pressed)
				SceneSwitcherWindow.Open();
		}
	}
}
