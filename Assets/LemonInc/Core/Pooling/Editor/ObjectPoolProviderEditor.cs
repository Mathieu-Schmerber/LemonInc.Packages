using LemonInc.Core.Pooling.Contracts;
using LemonInc.Core.Pooling.Providers;
using LemonInc.Editor.Utilities;
using LemonInc.Editor.Utilities.Helpers;
using Sirenix.Utilities.Editor;
using System.IO;
using LemonInc.Core.Pooling.Editor.Configuration;
using LemonInc.Editor.Utilities.Extensions;
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
		/// The automatic generate.
		/// </summary>
		private bool _autoGenerate = false;

		/// <summary>
		/// Styles used.
		/// </summary>
		public static class Styles
		{
			public static Color IndianRed = new(205 / 255f, 92 / 255f, 92 / 255f);

			public static GUIStyle btnActive = GUI.skin.button;
			public static GUIStyle btnDisabled = new GUIStyle(GUI.skin.button).WithNormalBackground(IndianRed);
			public static GUIStyle errorMessage = new GUIStyle(GUI.skin.label).WithFontStyle(FontStyle.Bold).WithTextColor(IndianRed, IndianRed);
			public static GUIStyle iconButton = new GUIStyle(GUI.skin.button).WithPadding(new RectOffset(1, 1, 1, 1)).WithFixedWidth(20).WithFixedHeight(20);
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
			else if (_prefab.GetComponent<IPoolable>() == null)
				return (false, "Prefab must implement IPoolable.");

			for (var i = 0; i < _target.transform.childCount; i++)
			{
				if (_target.transform.GetChild(i).name.Equals(PoolNamePolicy<string>.GetPoolName(_poolKey)))
					return (false, $"Pool '{_poolKey}' already exists.");
			}

			return (true, string.Empty);
		}

		private void OnEnable()
		{
			var form = PoolingConfiguration.Instance.LastFormState;
			_prefab = form.Prefab;
			_poolKey = form.Key;
			_initialCount = form.InitialCount;
			_autoGenerate = form.AutoGenerateOnCreate;
		}

		/// <summary>
		/// On Inspector GUI.
		/// </summary>
		public override void OnInspectorGUI()
		{
			_target = target as NamedObjectPoolProvider;

			base.OnInspectorGUI();
			DrawPoolList();
			DrawPoolCreator();
		}

		private void Generate()
		{
			var output = Path.GetFullPath("Assets/Plugins/LemonInc/Resources/Pooling/Pooling.cs");
			NamedPoolingCodeGenerator.GenerateScript(_target, output, true);
		}

		/// <summary>
		/// Draws the pool list.
		/// </summary>
		private void DrawPoolList()
		{
			var pools = _target.GetPools();

			SirenixEditorGUI.BeginBox();
			{
				SirenixEditorGUI.BeginBoxHeader();
				{
					GUILayout.BeginHorizontal();
					GUILayout.Label("Pools");
					GUILayout.FlexibleSpace();
					if (GUILayout.Button("Generate script"))
					{
						Generate();
					}
					GUILayout.EndHorizontal();
				}
				SirenixEditorGUI.EndBoxHeader();

				if (pools.Count == 0)
				{
					GUILayout.Label("<i>No Pool created yet.</i>", GUIStyle.none.WithRichText().WithTextColor(Color.white, Color.white));
				}
				else
				{
					SirenixEditorGUI.BeginVerticalList(false);
					{
						foreach (var pool in pools)
						{
							var value = pool.Value as ObjectPool;
							SirenixEditorGUI.BeginListItem();
							{
								GUILayout.BeginHorizontal();
								{
									GUILayout.Label(pool.Key);
									if (GUILayout.Button(EditorIcons.Animationvisibilitytoggleon.image, Styles.iconButton))
										Selection.SetActiveObjectWithContext(value, value);
									if (GUILayout.Button(EditorIcons.DProject2X.image, Styles.iconButton))
										GUIUtility.systemCopyBuffer = pool.Key;
								}
								GUILayout.EndHorizontal();
							}
							SirenixEditorGUI.EndListItem();
						}
					}
					SirenixEditorGUI.EndVerticalList();
				}
			}
			SirenixEditorGUI.EndBox();
		}

		/// <summary>
		/// Draws the pool creator.
		/// </summary>
		private void DrawPoolCreator()
		{
			EditorGUI.BeginChangeCheck();

			SirenixEditorGUI.BeginBox("Pool creator");
			{
				var prefab = EditorGUILayout.ObjectField(new GUIContent("Prefab", EditorIcons.DPrematcube.image),
					_prefab, typeof(GameObject), false) as GameObject;
				if (_prefab != prefab)
				{
					_prefab = prefab;
					_poolKey = _prefab?.name ?? _poolKey;
				}

				_poolKey = EditorGUILayout.TextField(new GUIContent("Pool Key", EditorIcons.Jointangularlimits.image),
					_poolKey);
				_initialCount = EditorGUILayout.IntField(new GUIContent("Initial count", EditorIcons.Settings.image),
					_initialCount);

				GUILayout.Space(10);

				var canCreate = CanCreate();
				if (!canCreate.success)
					EditorMessageBox.Error(canCreate.error);

				// TODO: read from config
				GUILayout.Space(5);
				_autoGenerate = GUILayout.Toggle(_autoGenerate, "Generate script on pool creation");
				GUILayout.Space(5);

				if (GUILayout.Button("Create Pool", canCreate.success ? Styles.btnActive : Styles.btnDisabled) &&
				    canCreate.success)
				{
					_target.Create(_poolKey, new PoolSettings()
					{
						Prefab = _prefab,
						InitialCount = _initialCount
					});

					_poolKey = string.Empty;
					_prefab = null;

					if (_autoGenerate)
						Generate();
				}

				GUILayout.Space(5);
			}
			SirenixEditorGUI.EndBox();

			if (EditorGUI.EndChangeCheck())
			{
				PoolingConfiguration.Instance.LastFormState = new PoolingConfiguration.PoolCreatorForm(_prefab, _initialCount, _poolKey, _autoGenerate);
				PoolingConfiguration.Instance.Save();
			}
		}
	}
}
