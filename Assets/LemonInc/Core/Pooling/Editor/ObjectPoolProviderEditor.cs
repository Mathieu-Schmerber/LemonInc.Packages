using Codice.Client.BaseCommands;
using LemonInc.Core.Pooling.Contracts;
using LemonInc.Core.Pooling.Providers;
using LemonInc.Editor.Utilities;
using LemonInc.Editor.Utilities.Helpers;
using Sirenix.Utilities.Editor;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEditor;
using UnityEngine;
using EditorIcons = LemonInc.Editor.Utilities.EditorIcons;

namespace LemonInc.Core.Pooling.Editor
{
	/// <summary>
	/// Editor for <see cref="NamedObjectPoolProvider"/>.
	/// </summary>
	/// <seealso cref="UnityEditor.Editor" />
	[CustomEditor(typeof(NamedObjectPoolProvider), editorForChildClasses: true)]
    public class ObjectPoolProviderEditor : UnityEditor.Editor
	{
		/// <summary>
		/// The pool key.
		/// </summary>
		private string _poolKey;

		/// <summary>
		/// The prefab.
		/// </summary>
		private GameObject _prefab;

		/// <summary>
		/// The initial count.
		/// </summary>
		private int _initialCount = 10;

		/// <summary>
		/// The object reference.
		/// </summary>
		private NamedObjectPoolProvider _target;

		/// <summary>
		/// Styles used.
		/// </summary>
		public static class Styles
		{
			public static Color IndianRed = new(205 / 255f, 92 / 255f, 92 / 255f);

			public static GUIStyle btnActive = GUI.skin.button;
			public static GUIStyle btnDisabled = new GUIStyle(GUI.skin.button).WithNormalBackground(IndianRed);
			public static GUIStyle errorMessage = new GUIStyle(GUI.skin.label).WithFontStyle(FontStyle.Bold).WithTextColor(IndianRed, IndianRed);
		}

		/// <summary>
		/// Checks if creation is possible.
		/// </summary>
		/// <returns>(<see cref="bool"/> can create, <see cref="string"/> error message)</returns>
		private (bool success, string error) CanCreate()
		{
			if (string.IsNullOrEmpty(_poolKey))
				return (false, $"Pool Key cannot be null.");
			else if (_prefab == null)
				return (false, $"Prefab cannot be null.");

			for (int i = 0; i < _target.transform.childCount; i++)
			{
				if (_target.transform.GetChild(i).name.Equals(PoolNamePolicy<string>.GetPoolName(_poolKey)))
					return (false, $"Pool '{_poolKey}' already exists.");
			}

			return (true, string.Empty);
		}

		/// <summary>
		/// On Inspector GUI.
		/// </summary>
		public override void OnInspectorGUI()
		{
			_target = target as NamedObjectPoolProvider;

			GameObject prefab = EditorGUILayout.ObjectField(new GUIContent("Prefab", EditorIcons.DPrematcube.image), _prefab, typeof(GameObject), false) as GameObject;
		    if (_prefab != prefab)
		    {
				_prefab = prefab;
				_poolKey = _prefab?.name ?? _poolKey;
		    }
			
		    _poolKey = EditorGUILayout.TextField(new GUIContent("Pool Key", EditorIcons.Jointangularlimits.image), _poolKey);
		    _initialCount = EditorGUILayout.IntField(new GUIContent("Initial count", EditorIcons.Settings.image), _initialCount);

			GUILayout.Space(10);
			GuiHelper.DrawLineSeparator();
			GUILayout.Space(10);

			var canCreate = CanCreate();
			if (!canCreate.success)
			    GUILayout.Label(new GUIContent(canCreate.error, EditorIcons.ConsoleErroricon.image), Styles.errorMessage);
		    if (GUILayout.Button("Create Pool", canCreate.success ? Styles.btnActive : Styles.btnDisabled) && canCreate.success)
		    {
			    _target.Create(_poolKey, new PoolSettings()
				{
					Prefab = _prefab,
					InitialCount = _initialCount
				});

				_poolKey = string.Empty;
				_prefab = null;
			}
	    }
    }
}
