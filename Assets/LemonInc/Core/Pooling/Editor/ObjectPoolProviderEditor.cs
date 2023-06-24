using Codice.Client.BaseCommands;
using LemonInc.Core.Pooling.Contracts;
using LemonInc.Core.Pooling.Providers;
using LemonInc.Editor.Utilities;
using LemonInc.Editor.Utilities.Helpers;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Pooling.Editor
{
	/// <summary>
	/// Editor for <see cref="NamedObjectPoolProvider"/>.
	/// </summary>
	/// <seealso cref="UnityEditor.Editor" />
	[CustomEditor(typeof(NamedObjectPoolProvider), editorForChildClasses: true)]
    public class ObjectPoolProviderEditor : UnityEditor.Editor
	{
		private string _poolId;
		private GameObject _prefab;
		private int _initialCount = 10;

		private NamedObjectPoolProvider _target;

		public static class Styles
		{
			public static GUIStyle btnActive = GUI.skin.button;
			public static GUIStyle btnDisabled = new GUIStyle(GUI.skin.button).WithTextColor(Color.red, Color.red);
			public static GUIStyle errorMessage = new GUIStyle(GUI.skin.label).WithTextColor(Color.red, Color.red);
		}

		private (bool success, string error) CanCreate()
		{
			if (string.IsNullOrEmpty(_poolId))
				return (false, $"Pool Id cannot be null.");
			else if (_prefab == null)
				return (false, $"Prefab cannot be null.");

			for (int i = 0; i < _target.transform.childCount; i++)
			{
				if (_target.transform.GetChild(i).name.Equals(PoolNamePolicy<string>.GetPoolName(_poolId)))
					return (false, $"Pool '{_poolId}' already exists.");
			}

			return (true, string.Empty);
		}

		public override void OnInspectorGUI()
		{
			_target = target as NamedObjectPoolProvider;

			GameObject prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
		    if (_prefab != prefab)
		    {
				_prefab = prefab;
				_poolId = _prefab?.name ?? _poolId;
		    }

		    _poolId = EditorGUILayout.TextField("Pool Id", _poolId);
		    _initialCount = EditorGUILayout.IntField("Initial count", _initialCount);

			GuiHelper.DrawLineSeparator();

		    var canCreate = CanCreate();
			if (!canCreate.success)
			    GUILayout.Label(canCreate.error, Styles.errorMessage);
		    if (GUILayout.Button("Create Pool", canCreate.success ? Styles.btnActive : Styles.btnDisabled) && canCreate.success)
		    {
			    _target.Create(_poolId, new PoolSettings()
				{
					Prefab = _prefab,
					InitialCount = _initialCount
				});

				_poolId = string.Empty;
				_prefab = null;
			}
	    }
    }
}
