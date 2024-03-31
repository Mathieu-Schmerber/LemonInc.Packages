using System.Linq;
using LemonInc.Core.Utilities.Editor.Helpers;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.SceneSwitcher.Editor
{
	/// <summary>
	/// Scene switcher window.
	/// </summary>
	/// <seealso cref="UnityEditor.EditorWindow" />
	public class SceneSwitcherWindow : EditorWindow
	{
		[SerializeField] private VisualTreeAsset _uxml;
		
		private static SceneItem[] _scenes;
		private Vector2 _scollPos;
		private int _activeScene;

		private ListView _sceneView;

		/// <summary>
		/// The maximum elements.
		/// </summary>
		private const int MAX_ELEMENTS = 10;

		/// <summary>
		/// The element size.
		/// </summary>
		private const int ELEMENT_SIZE = 22;

		/// <summary>
		/// Opens this instance.
		/// </summary>
		public static void Open()
		{
			var window = ScriptableObject.CreateInstance<SceneSwitcherWindow>();
			_scenes = GetScenes();
			var size = new Vector2(225, ProcessSize(_scenes.Length));
			var win = EditorGUIUtility.GetMainWindowPosition();

			// Calculating window ratios to center the window next to the play button
			var pos = new Vector2(win.x + (win.width * .415f) - (size.x * .5f), win.y + EditorGUIUtility.singleLineHeight * 1.5f);
			window.position = new Rect(pos.x, pos.y, size.x, size.y );
			
			window.ShowPopup();
			window.Focus();
		}

		/// <summary>
		/// Processes the size.
		/// </summary>
		private static float ProcessSize(int elementNumber) => Mathf.Clamp(elementNumber, 0, MAX_ELEMENTS) * ELEMENT_SIZE + 6; //+2 for border size

		/// <summary>
		/// Gets the scenes.
		/// </summary>
		/// <returns></returns>
		private static SceneItem[] GetScenes()
		{
			var loaded = EditorSceneManager.GetAllScenes();
			var result = SceneHelper.GetAllScenesInProject()
				.Select(x => new SceneItem(x.Path, x.BuildIndex)
				{
					Active = loaded.Any(y => y.name.Equals(x.Name))
				})
				.OrderBy(x => x.DisplayName).ToArray();

			return result;
		}

		/// <summary>
		/// Creates the GUI.
		/// </summary>
		private void CreateGUI()
		{
			_uxml.CloneTree(rootVisualElement);
			_sceneView = rootVisualElement.Q<ListView>();

			Init();
		}

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
			_activeScene = GetActiveSceneIndex(_scenes);

			_sceneView.makeItem = () =>
			{
				var root = new VisualElement()
				{
					style =
					{
						flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row),
						alignItems = new StyleEnum<Align>(Align.Center),
						justifyContent = new StyleEnum<Justify>(Justify.SpaceBetween)
					}
				};

				var label = new Label();
				var button = new Button()
				{
					text = "+"
				};

				root.Add(label);
				root.Add(button);
				return root;
			};

			_sceneView.bindItem = (element, index) =>
			{
				var root = element;
				var label = root.Q<Label>();
				var button = root.Q<Button>();

				label.text = _scenes[index].DisplayName;
				label.style.color = _scenes[index].Active ? new StyleColor(Color.cyan) : new StyleColor(Color.white);
				button.SetEnabled(!_scenes[index].Active);

				button.clicked += () =>
				{
					_scenes[index].Active = true;
					label.style.color = new StyleColor(Color.cyan);
					AddScene(_scenes[index]);
					button.SetEnabled(!_scenes[index].Active);
				};
			};

			_sceneView.itemsSource = _scenes;
			_sceneView.selectionChanged += OnSceneSelected;
		}

		/// <summary>
		/// Called when [scene selected].
		/// </summary>
		/// <param name="obj">The object.</param>
		private void OnSceneSelected(System.Collections.Generic.IEnumerable<object> obj)
		{
			SceneItem scene = _scenes[_sceneView.selectedIndex];

			EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
			EditorSceneManager.OpenScene(scene.Path, OpenSceneMode.Single);
			Close();
		}

		/// <summary>
		/// Adds the scene.
		/// </summary>
		/// <param name="scene">The scene.</param>
		private void AddScene(SceneItem scene)
		{
			EditorSceneManager.OpenScene(scene.Path, OpenSceneMode.Additive);
		}

		/// <summary>
		/// Closes the window.
		/// </summary>
		private void CloseWindow() => Close();

		/// <summary>
		/// Called when [lost focus].
		/// </summary>
		private void OnLostFocus() => CloseWindow();
	}
}
