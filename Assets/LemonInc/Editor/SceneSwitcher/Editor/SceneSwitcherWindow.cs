using System.IO;
using System.Linq;
using LemonInc.Editor.Utilities.Helpers;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace LemonInc.Editor.SceneSwitcher
{
	/// <summary>
	/// Scene switcher window.
	/// </summary>
	/// <seealso cref="UnityEditor.EditorWindow" />
	public class SceneSwitcherWindow : EditorWindow
	{
		#region Types		
		/// <summary>
		/// Describes a scene item.
		/// </summary>
		[System.Serializable]
		public struct SceneItem
		{
			/// <summary>
			/// Gets the name.
			/// </summary>
			public string Name => System.IO.Path.GetFileNameWithoutExtension(Path);

			/// <summary>
			/// Gets the display name.
			/// </summary>
			public string DisplayName => $"{Directory.GetParent(Path).Parent.Name}\\{System.IO.Path.GetFileNameWithoutExtension(Path)}";

			/// <summary>
			/// Gets or sets the path.
			/// </summary>
			public string Path { get; set; }

			/// <summary>
			/// Gets or sets the index of the build.
			/// </summary>
			public int BuildIndex { get; set; }

			/// <summary>
			/// Initializes a new instance of the <see cref="SceneItem"/> struct.
			/// </summary>
			/// <param name="path">The path.</param>
			/// <param name="buildIndex">Index of the build.</param>
			public SceneItem(string path, int buildIndex)
			{
				Path = path;
				BuildIndex = buildIndex;
			}
		}
		#endregion

		/// <summary>
		/// The styles.
		/// </summary>
		public static class Styles
		{
			/// <summary>
			/// The window style.
			/// </summary>
			public static GUIStyle WindowStyle = new GUIStyle(GUIStyle.none)
				.WithNormalBackground(GuiHelper.LightColor)
				.WithPadding(new RectOffset(1, 1, 1, 1));

			/// <summary>
			/// Gets the specified base style.
			/// </summary>
			/// <param name="baseStyle">The base style.</param>
			/// <param name="normal">The normal.</param>
			/// <returns></returns>
			public static GUIStyle Get(GUIStyle baseStyle, Color normal)
			{
				GUIStyle style = new(baseStyle);
				var ntexture = new Texture2D(1, 1);
				var htexture = new Texture2D(1, 1);

				ntexture.SetPixel(0, 0, normal);
				ntexture.Apply();
				style.normal.background = ntexture;

				htexture.SetPixel(0, 0, new Color(normal.r + .2f, normal.g + .2f, normal.b + .2f));
				htexture.Apply();
				style.hover.background = htexture;
				return style;
			}
		}

		private SceneItem[] _scenes;
		private Vector2 _scollPos;
		private int _activeScene;

		/// <summary>
		/// Opens this instance.
		/// </summary>
		public static void Open()
		{
			var window = ScriptableObject.CreateInstance<SceneSwitcherWindow>();
			var size = new Vector2(225, 300);
			var win = EditorGUIUtility.GetMainWindowPosition();

			// Calculating window ratios to center the window next to the play button
			var pos = new Vector2(win.x + (win.width * .415f) - (size.x * .5f), win.y + EditorGUIUtility.singleLineHeight * 1.5f);

			window.Init();
			window.position = new Rect(pos.x, pos.y, size.x, window.GetMinimumHeight());
			window.ShowPopup();
			window.Focus();
		}

		/// <summary>
		/// Gets the minimum height.
		/// </summary>
		/// <returns></returns>
		private float GetMinimumHeight() => (_scenes.Length + 1) * EditorGUIUtility.singleLineHeight + 8;

		/// <summary>
		/// Gets the index of the active scene.
		/// </summary>
		/// <param name="array">The array.</param>
		/// <returns></returns>
		private static int GetActiveSceneIndex(SceneItem[] array)
		{
			var name = EditorSceneManager.GetActiveScene().name;

			for (var i = 0; i < array.Length; i++)
				if (array[i].Name == name)
					return i;
			return 0;
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		private void Init()
		{
			_scenes = SceneHelper.GetAllScenesInProject().Select(x => new SceneItem(x.Path, x.BuildIndex)).OrderBy(x => x.DisplayName).ToArray();
			_activeScene = GetActiveSceneIndex(_scenes);
		}

		/// <summary>
		/// Closes the window.
		/// </summary>
		private void CloseWindow()
		{
			Close();
		}

		/// <summary>
		/// Called when [lost focus].
		/// </summary>
		private void OnLostFocus() => CloseWindow();

		/// <summary>
		/// Called when [GUI].
		/// </summary>
		private void OnGUI()
		{
			var evenBtn = EditorStyles.toolbarButton;
			var oddBtn = Styles.Get(EditorStyles.toolbarButton, new Color(.2f, .2f, .2f, 1f));

			EditorGUILayout.BeginVertical(Styles.WindowStyle);
			{
				_scollPos = EditorGUILayout.BeginScrollView(_scollPos);
				{
					for (var i = 0; i < _scenes.Length; i++)
					{
						var item = _scenes[i];

						EditorGUILayout.BeginHorizontal(i % 2 == 0 ? evenBtn : oddBtn);
						{
							if (GUILayout.Button(item.DisplayName, i == _activeScene ? EditorStyles.boldLabel : EditorStyles.label))
							{
								EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
								EditorSceneManager.OpenScene(item.Path, OpenSceneMode.Single);
								Close();
							}
							if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.ExpandHeight(true)))
								EditorSceneManager.OpenScene(item.Path, OpenSceneMode.Additive);
						}
						EditorGUILayout.EndHorizontal();
					}
				}
				EditorGUILayout.EndScrollView();
			}
			EditorGUILayout.EndVertical();
		}
	}
}
