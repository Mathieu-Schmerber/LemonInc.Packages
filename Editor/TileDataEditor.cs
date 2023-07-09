using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LemonInc.Editor.Utilities;
using LemonInc.Editor.Utilities.Helpers;
using LemonInc.Tools.Tilemap.Data;
using LemonInc.Tools.Tilemap.Data.TileProperties;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LemonInc.Tools.Tilemap.Editor
{
	[CustomEditor(typeof(TileData))]
	public class TileDataEditor : UnityEditor.Editor
	{
		private TileData _tileData;
		private List<bool> _foldouts = new();

		private void OnEnable()
		{
			_tileData = target as TileData;

			if (_tileData == null || _tileData.Properties == null)
				return;

			_foldouts = Enumerable.Repeat(false, _tileData.Properties.Count).ToList();
		}

		public override void OnInspectorGUI()
		{
			// Get latest version
			serializedObject.Update();

			EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(TileData.Prefab)));

			if (_tileData.Prefab != null)
			{
				GUILayout.BeginHorizontal();
				{
					EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(TileData.Texture)));
					DrawButton(new GUIContent("Generate"), () => GenerateThumbnail(), GUILayout.ExpandWidth(false));
				}
				GUILayout.EndHorizontal();
				DrawProperties();
			}

			// Save
			serializedObject.ApplyModifiedProperties();
		}

		#region Utilities

		private void DrawButton(GUIContent content, Action clickCallback, params GUILayoutOption[] options)
			=> DrawButton(content, clickCallback, GUI.skin.button, options);

		private void DrawButton(GUIContent content, Action clickCallback, GUIStyle style, params GUILayoutOption[] options)
		{
			if (GUILayout.Button(content, style, options))
				clickCallback?.Invoke();
		}

		private void GenerateThumbnail(bool retry = true)
		{
			var preview = AssetPreview.GetAssetPreview(_tileData.Prefab.gameObject);
			while (AssetPreview.IsLoadingAssetPreview(_tileData.Prefab.GetInstanceID())) ;

			if (preview == null)
			{
				if (retry)
					GenerateThumbnail(false);
				return;
			}

			var myPath = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this));
			var fullPath = EditorUtility.SaveFilePanel("Save thumbnail", myPath, $"{name}_thumb", "png");

			if (string.IsNullOrEmpty(fullPath))
				return;

			var unityPath = fullPath.Remove(0, fullPath.IndexOf("Assets"));

			File.WriteAllBytes(fullPath, preview.EncodeToPNG());
			AssetDatabase.Refresh();
			_tileData.Texture = (Texture2D)AssetDatabase.LoadAssetAtPath(unityPath, typeof(Texture2D));
			Save();
		}

		private void SetProperty(TileProperty property, Vector2Int index, TileData data)
		{
			if (property.Neighboring.ContainsKey(index))
			{
				property.Neighboring[index] = data;
				Save();
			}
		}

		private void Save()
		{
			EditorUtility.SetDirty(_tileData);
			AssetDatabase.SaveAssets();
		}

		#endregion

		#region Properties logic

		private void AssignSelectedTileData(TileProperty property, Vector2Int index)
		{
			var context = new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition), 100, 100);
			SearchWindow.Open(context, new AssetSearchProvider<TileData>(
				onEntrySelected: (entry) => {
					SetProperty(property, index, entry);
				}));
		}

		private void HandleMouseEvents<T>(Rect rect, Action<T> onDragged, Action onLeftClick, Action onRightClick)
		{
			if (!rect.Contains(Event.current.mousePosition))
				return;

			var dragData = DragAndDrop.objectReferences.OfType<T>().FirstOrDefault();

			if (dragData != null)
			{
				if (Event.current.type == EventType.DragUpdated)
				{
					DragAndDrop.visualMode = DragAndDropVisualMode.Move;
					Event.current.Use();
				}
				else if (Event.current.type == EventType.DragPerform)
				{
					onDragged?.Invoke(dragData);
					Event.current.Use();
				}
			}
			else if (Event.current.type == EventType.MouseDown)
			{
				if (Event.current.button == 0)
					onLeftClick?.Invoke();
				else if (Event.current.button == 1)
					onRightClick?.Invoke();
				Event.current.Use();
			}
		}

		#endregion

		#region Properties UI

		private void DrawPropertiesBody()
		{
			for (var i = 0; i < _tileData.Properties.Count; i++)
			{
				GUILayout.BeginHorizontal();
				{
					_foldouts[i] = EditorGUILayout.Foldout(_foldouts[i], new GUIContent($"Property {i + 1}"), true);
					DrawButton(new GUIContent(EditorGUIUtility.IconContent("P4_DeletedLocal")), () => {
						_tileData.Properties.Remove(_tileData.Properties[i]);
						i--;
						Save();
					}, new GUIStyle(), GUILayout.ExpandWidth(false));
				}
				GUILayout.EndHorizontal();
				if (i < 0)
					break;
				var rect = GUILayoutUtility.GetLastRect();
				var underline = new Rect(rect.xMin, rect.yMax, rect.size.x, 1);
				GUI.Box(underline, "", GUI.skin.box);

				if (_foldouts[i])
				{
					GUILayout.Space(5);

					GUILayout.BeginHorizontal();
					{
						DrawPropertyGrid(_tileData.Properties[i]);

						GUILayout.BeginVertical();
						DrawPropertySettings(_tileData.Properties[i]);
						GUILayout.EndVertical();

					}
					GUILayout.EndHorizontal();
				}
			}
		}

		private void DrawProperties()
		{
			_tileData.Properties ??= new List<TileProperty>();
			SirenixEditorGUI.BeginBox();
			{
				SirenixEditorGUI.BeginBoxHeader();
				{
					GUILayout.Label("Properties", EditorStyles.boldLabel);
					DrawButton(new GUIContent(EditorGUIUtility.IconContent("P4_AddedRemote")), () =>
					{
						_tileData.Properties.Add(new TileProperty(_tileData.Prefab));
						_foldouts.Add(true);
					}, new GUIStyle().WithAlignment(TextAnchor.MiddleCenter), GUILayout.ExpandWidth(false), GUILayout.Height(20));
				}
				SirenixEditorGUI.EndBoxHeader();

				if (_tileData.Properties != null)
					DrawPropertiesBody();
			}
			SirenixEditorGUI.EndBox();
		}

		private void DrawPropertyGrid(TileProperty property)
		{
			var min = property.Neighboring.Keys.Aggregate((a, b) => new Vector2Int(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y)));
			var max = property.Neighboring.Keys.Aggregate((a, b) => new Vector2Int(Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y)));
			var size = new Vector2Int(max.x - min.x + 1, max.y - min.y + 1);
			var TILE_SIZE = 50;

			var container = GUILayoutUtility.GetRect(size.x * TILE_SIZE, size.y * TILE_SIZE, GUILayout.ExpandWidth(false));

			for (int w = 0, x = min.x; w < size.x; w++, x++)
			{
				for (int h = 0, y = max.y; h < size.y; h++, y--)
				{
					var pos = new Vector2Int(x, y);
					var tileRect = new Rect(container.x + w * TILE_SIZE, container.y + h * TILE_SIZE, TILE_SIZE, TILE_SIZE);

					if (property.Neighboring.ContainsKey(pos))
					{
						GUI.Box(tileRect, new GUIContent(property.Neighboring[pos]?.Texture), property.Neighboring[pos] == null ? GUI.skin.textField : GUI.skin.box);
						HandleMouseEvents<TileData>(tileRect,
							onDragged: (data) => SetProperty(property, pos, data),
							onLeftClick: () => AssignSelectedTileData(property, pos),
							onRightClick: () => {
								GenericMenu menu = new();
								menu.AddItem(new GUIContent("Delete"), false, () => SetProperty(property, pos, null));
								menu.ShowAsContext();
							});
					}
					else if (pos == Vector2Int.zero)
					{
						GUI.Box(tileRect, new GUIContent(AssetPreview.GetAssetPreview(property.Outcome?.gameObject)), property.Outcome == null ? GUI.skin.textField : GUI.skin.box);
						HandleMouseEvents<GameObject>(tileRect,
							onDragged: (data) => {
								property.Outcome = data;
								Save();
							},
							onLeftClick: null,
							onRightClick: null);
					}
				}
			}
		}

		private void DrawPropertySettings(TileProperty tileProperty)
		{
			var index = _tileData.Properties.IndexOf(tileProperty);
			var property = serializedObject.FindProperty(nameof(TileData.Properties)).GetArrayElementAtIndex(index);

			EditorGUILayout.PropertyField(property.FindPropertyRelative(nameof(TileProperty.Rotate)));
			EditorGUILayout.PropertyField(property.FindPropertyRelative(nameof(TileProperty.RotateTile)));
			EditorGUILayout.PropertyField(property.FindPropertyRelative(nameof(TileProperty.Mirror)));
			EditorGUILayout.PropertyField(property.FindPropertyRelative(nameof(TileProperty.Random)));
		}

		#endregion
	}
}