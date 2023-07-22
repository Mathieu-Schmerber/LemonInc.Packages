using LemonInc.Editor.Utilities.Helpers;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Editor.Utilities
{
	/// <summary>
	/// Editor message box.
	/// </summary>
	public static class EditorMessageBox
	{
		public static class Styles
		{
			public static GUIStyle WrappingLabel = new GUIStyle(EditorStyles.wordWrappedLabel).WithAlignment(TextAnchor.MiddleLeft);
		}

		/// <summary>
		/// Shows the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Success(string message)
		{
			var color = GUI.color;
			var height = EditorGUIUtility.singleLineHeight * 1.5f;
			var baseSize = EditorGUIUtility.GetIconSize();

			EditorGUIUtility.SetIconSize(Vector2.one * height);
			SirenixEditorGUI.BeginBox();
			{
				GUILayout.BeginHorizontal();
				{
					GUI.color = Color.green;
					GUILayout.BeginVertical(GUILayout.Width(height));
					{
						GUILayout.FlexibleSpace();
						GUILayout.Label(new GUIContent(EditorIcons.Progress2X.image));
						GUILayout.FlexibleSpace();
					}
					GUILayout.EndVertical();

					GUILayout.BeginVertical();
					{
						GUI.color = color;
						GUILayout.FlexibleSpace();
						GUILayout.Label(message, Styles.WrappingLabel);
						GUILayout.FlexibleSpace();
					}
					GUILayout.EndVertical();
				}
				GUILayout.EndHorizontal();
			}
			SirenixEditorGUI.EndBox();
			EditorGUIUtility.SetIconSize(baseSize);
		}

		/// <summary>
		/// Shows the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Error(string message)
		{
			var color = GUI.color;
			var height = EditorGUIUtility.singleLineHeight * 1.5f;
			var baseSize = EditorGUIUtility.GetIconSize();

			EditorGUIUtility.SetIconSize(Vector2.one * height);
			SirenixEditorGUI.BeginBox();
			{
				GUILayout.BeginHorizontal();
				{
					GUI.color = new Color(205 / 255f, 82 / 255f, 82 / 255f);
					GUILayout.BeginVertical(GUILayout.Width(height));
					{
						GUILayout.FlexibleSpace();
						GUILayout.Label(new GUIContent(EditorIcons.ConsoleErroricon2X.image));
						GUILayout.FlexibleSpace();
					}
					GUILayout.EndVertical();

					GUILayout.BeginVertical();
					{
						GUI.color = color;
						GUILayout.FlexibleSpace();
						GUILayout.Label(message, Styles.WrappingLabel);
						GUILayout.FlexibleSpace();
					}
					GUILayout.EndVertical();
				}
				GUILayout.EndHorizontal();
			}
			SirenixEditorGUI.EndBox();
			EditorGUIUtility.SetIconSize(baseSize);
		}
	}
}