using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LemonInc.Core.Utilities.Editor.Helpers
{
	/// <summary>
	/// Scene access utility for editor tools.
	/// </summary>
	public static class SceneHelper
	{
		/// <summary>
		/// Custom scene data structure
		/// </summary>
		public readonly struct SceneInfo
		{
			/// <summary>
			/// The name of the <see cref="UnityEngine.SceneManagement.Scene"/>.
			/// </summary>
			public string Name { get; }

			/// <summary>
			/// The full path of the scene.
			/// </summary>
			public string Path { get; }

			/// <summary>
			/// Build index of the scene.
			/// </summary>
			public int BuildIndex { get; }

			/// <summary>
			/// The scene object.
			/// </summary>
			public Scene Scene { get; }

			/// <summary>
			/// Whether ths scene is open in the editor.
			/// </summary>
			public bool IsOpen => Scene.IsValid();

			public SceneInfo(string name, string path, Scene scene)
			{
				Name = name;
				Path = path;
				Scene = scene;
				BuildIndex = scene.IsValid() ? scene.buildIndex : -1;
			}
		}

		/// <summary>
		/// Gets all scenes in the project.
		/// </summary>
		/// <returns>An array of <see cref="SceneInfo"/>.</returns>
		public static SceneInfo[] GetAllScenesInProject()
		{
			string[] paths = Directory.GetFiles(Application.dataPath, "*.unity", SearchOption.AllDirectories);

			return paths.Select(GetSceneAtPath).ToArray();
		}

		/// <summary>
		/// Gets all scenes with a build index.
		/// </summary>
		/// <returns>An array of <see cref="SceneInfo"/>.</returns>
		public static SceneInfo[] GetAllBuiltScene() => EditorBuildSettings.scenes.Select(x => GetSceneAtPath(x.path)).ToArray();

		/// <summary>
		/// Gets scene at path.
		/// </summary>
		/// <param name="path">The scene full path.</param>
		/// <returns></returns>
		public static SceneInfo GetSceneAtPath(string path)
		{
			var scene = EditorSceneManager.GetSceneByPath(path);

			return new SceneInfo(Path.GetFileNameWithoutExtension(path), path, scene);
		}
	}
}