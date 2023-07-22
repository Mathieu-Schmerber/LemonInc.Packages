using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Grid.Extensions;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Editor.Utilities;
using LemonInc.Editor.Utilities.Extensions;
using LemonInc.Editor.Utilities.Helpers;
using LemonInc.Tools.Tilemap.Data;
using LemonInc.Tools.Tilemap.Editor.Interfaces;
using LemonInc.Tools.Tilemap.Editor.Tools;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LemonInc.Tools.Tilemap.Editor
{
	/// <summary>
	/// Tilemap editor tool.
	/// </summary>
	[CustomEditor(typeof(Tilemap))]
	public class TilemapEditor : UnityEditor.Editor
	{
		private enum TilemapTool
		{
			Brush,
			Eraser,
			SquareBrush,
			SquareEraser
		}

		private Tilemap _tilemap;

		private Dictionary<TilemapTool, ITilemapToolHandle> _tools;
		private ITilemapToolHandle _tool;

		private void OnEnable()
		{
			_tools = new Dictionary<TilemapTool, ITilemapToolHandle>()
			{
				{ TilemapTool.Brush, new BrushToolHandle(SelectTiles, DrawTiles, EraseTiles) },
				{ TilemapTool.Eraser, new EraserToolHandle(SelectTiles, DrawTiles, EraseTiles) },
				{ TilemapTool.SquareBrush, new SquareBrushToolHandle(SelectTiles, DrawTiles, EraseTiles) },
				{ TilemapTool.SquareEraser, new SquareEraserToolHandle(SelectTiles, DrawTiles, EraseTiles) }
			};

			SelectTool(TilemapTool.Brush);
		}

		/// <summary>
		/// Called when drawing the inspector.
		/// </summary>
		public override void OnInspectorGUI()
		{
			_tilemap = target as Tilemap;
			UnityEditor.Tools.current = Tool.None;

			DrawUi();
			serializedObject.ApplyModifiedProperties();
		}

		private void SelectTool(TilemapTool tool)
		{
			_tool = _tools[tool];
		}

		/// <summary>
		/// Update loop.
		/// </summary>
		private void OnSceneGUI()
		{
			EditorApplication.QueuePlayerLoopUpdate();
			SceneView.RepaintAll();

			// Force tilemap focus, so we don't lose it when clicking tiles.
			HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

			if (_tilemap != null)
			{
				HandleMouseEvents();
			}
		}

		#region UI

		public static class Styles
		{
			public static GUIStyle SelectedButton => new GUIStyle(GUI.skin.button).WithNormalBackground(Color.blue.WithAlpha(.1f)).WithFixedSize(30, 30).WithAlignment(TextAnchor.MiddleCenter);
			public static GUIStyle UnselectedButton => new GUIStyle(GUI.skin.button).WithNormalBackground(Color.white.WithAlpha(0.1f)).WithFixedSize(30, 30).WithAlignment(TextAnchor.MiddleCenter);
			public static GUIStyle SelectedTile => new GUIStyle(GUI.skin.button)
				.WithNormalBackground(Color.blue.WithAlpha(.1f))
				.WithFixedSize(50, 50)
				.WithAlignment(TextAnchor.MiddleCenter);
			public static GUIStyle UnselectedTile => new GUIStyle(GUI.skin.button)
				.WithNormalBackground(Color.white.WithAlpha(0.1f))
				.WithFixedSize(50, 50)
				.WithAlignment(TextAnchor.MiddleCenter);
			public static GUIStyle DragBox => new GUIStyle(GUI.skin.window);
		}

		private void DrawToolButton(TilemapTool value, GUIContent content)
		{
			var pressed = _tool == _tools[value];
			var pressing = GUILayout.Button(content, pressed ? Styles.SelectedButton : Styles.UnselectedButton);

			if (!pressed && pressing)
				SelectTool(value);
		}

		private void HandleDragAndDrop(Rect rect)
		{
			if (!rect.Contains(Event.current.mousePosition))
				return;

			var data = DragAndDrop.objectReferences.OfType<TileData>();

			if (!data.Any())
				return;

			if (Event.current.type == EventType.DragUpdated)
			{
				DragAndDrop.visualMode = DragAndDropVisualMode.Move;
				Event.current.Use();
			}
			else if (Event.current.type == EventType.DragExited)
			{
				Event.current.Use();
				foreach (var tile in data)
				{
					if (!_tilemap.Palette.Contains(tile))
						_tilemap.Palette.Add(tile);
				}
				EditorUtility.SetDirty(target);
			}
		}

		private void DrawTileButton(Rect button, TileData tile, Action deleteCallback)
		{
			if (button.Contains(Event.current.mousePosition) && Event.current.type == EventType.MouseDown && Event.current.button == 1)
			{
				GenericMenu menu = new();
				menu.AddItem(new GUIContent("Delete"), false, () =>
				{
					_tilemap.Palette.Remove(tile);
					EditorUtility.SetDirty(target);
					deleteCallback?.Invoke();
				});
				menu.ShowAsContext();
				Event.current.Use();
			}

			if (GUI.Button(button, tile.Texture, _tilemap.Selected == tile ? Styles.SelectedTile : Styles.UnselectedTile))
				_tilemap.Selected = tile;
		}

		private void DrawPalette()
		{
			// Draw tiles
			var paletteLength = _tilemap.Palette.Count;
			var rowLength = 5;
			var rowNumber = Mathf.Max(Mathf.CeilToInt((float)paletteLength / rowLength), 1);
			var index = 0;
			float tileSize = 50;
			float padding = 10;
			float spacing = 5;

			var paletteRect = GUILayoutUtility.GetRect(rowLength * tileSize + padding * 2 + spacing * rowLength, rowNumber * tileSize + padding * 2 + spacing * rowNumber);

			GUI.Box(paletteRect, paletteLength == 0 ? "Drag and drop tiles here !" : "", Styles.DragBox);
			for (var y = 0; y < rowNumber && index < paletteLength; y++)
			{
				for (var x = 0; x < rowLength && index < paletteLength; x++, index++)
				{
					var buttonRect = new Rect(paletteRect.x + x * tileSize + padding + spacing * x, paletteRect.y + y * tileSize + padding, tileSize + spacing * y, tileSize);

					DrawTileButton(buttonRect, _tilemap.Palette[index], () => paletteLength--);
				}
			}

			HandleDragAndDrop(paletteRect);
		}

		private void DrawUi()
		{
			if (_tilemap.Data == null)
			{
				if (GUILayout.Button("Create Tilemap Asset"))
				{
					var myPath = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(this));
					var fullPath = EditorUtility.SaveFilePanel("Create tilemap", myPath, "TilemapAsset", "asset");

					if (string.IsNullOrEmpty(fullPath))
						return;

					var assetPath = fullPath.ToAssetPath();
					AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TilemapData>(), assetPath);
					AssetDatabase.Refresh();

					var data = AssetDatabase.LoadAssetAtPath<TilemapData>(assetPath);
					_tilemap.Data = data;
					EditorUtility.SetDirty(_tilemap);
				}
				if (GUILayout.Button("Load Tilemap Asset"))
				{
					SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)), new AssetSearchProvider<TilemapData>((entry) =>
					{
						_tilemap.Data = entry;
						EditorUtility.SetDirty(_tilemap);
					}));
				}
				return;
			}

			// Draw tools
			GUILayout.BeginHorizontal();
			{
				GUILayout.FlexibleSpace();
				DrawToolButton(TilemapTool.Brush, EditorGUIUtility.IconContent("d_Grid.PaintTool"));
				DrawToolButton(TilemapTool.Eraser, EditorGUIUtility.IconContent("d_Grid.EraserTool"));
				DrawToolButton(TilemapTool.SquareBrush, EditorGUIUtility.IconContent("d_SpriteAtlas On Icon"));
				DrawToolButton(TilemapTool.SquareEraser, EditorGUIUtility.IconContent("RectTool On"));
				GUILayout.FlexibleSpace();
			}
			GUILayout.EndHorizontal();

			GUILayout.Space(10);

			DrawPalette();
		}

		#endregion

		#region Controls

		/// <summary>
		/// Draws a cell.
		/// </summary>
		/// <param name="gridPosition">The cell world position.</param>
		/// <param name="color">The cell color.</param>
		private void DrawCell(Vector3Int gridPosition, Color color)
		{
			var snap = _tilemap.ToWorldPos(gridPosition);

			Handles.color = color;
			Handles.DrawAAConvexPolygon(
					snap + new Vector3(_tilemap.CellSize.x, 0, _tilemap.CellSize.z) * .5f,
					snap + new Vector3(_tilemap.CellSize.x, 0, -_tilemap.CellSize.z) * .5f,
					snap + new Vector3(-_tilemap.CellSize.x, 0, -_tilemap.CellSize.z) * .5f,
					snap + new Vector3(-_tilemap.CellSize.x, 0, _tilemap.CellSize.z) * .5f);
		}

		/// <summary>
		/// Handles mouse.
		/// </summary>
		private void HandleMouseEvents()
		{
			var sceneCamera = SceneView.lastActiveSceneView?.camera;

			if (sceneCamera == null)
				return;

			var e = Event.current;
			var currentLayerPlane = new Plane(Vector3.up, _tilemap.Origin);
			var ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
			var selectedCellPosition = currentLayerPlane.Raycast(ray, out var distance) ? _tilemap.ToGridPos(ray.GetPoint(distance)) : Vector3Int.zero;

			_tool.OnTileHover(selectedCellPosition);

			switch (e.type)
			{
				// Mouse click
				case EventType.MouseDown when e.button == 0:
					_tool.OnTileDown(selectedCellPosition);
					Event.current.Use();
					break;
				case EventType.MouseDrag when e.button == 0:
					_tool.OnTileDragged(selectedCellPosition);
					Event.current.Use();
					break;
				case EventType.MouseUp when e.button == 0:
					_tool.OnTileUp(selectedCellPosition);
					Event.current.Use();
					break;
			}
		}

		private void DrawTiles(IEnumerable<Vector3Int> tiles)
		{
			if (!_tilemap.Selected) 
				return;

			_tilemap.SetTiles(tiles, _tilemap.Selected);
			EditorUtility.SetDirty(target);
		}

		private void EraseTiles(IEnumerable<Vector3Int> tiles)
		{
			foreach (var item in tiles)
			{
				if (_tilemap.GetTile(item) != null)
					_tilemap.SetTile(item, null);
			}

			EditorUtility.SetDirty(target);
		}

		private void SelectTiles(IEnumerable<Vector3Int> tiles)
		{
			tiles.ForEach(x => DrawCell(x, new Color(1, 1, 1, 0.3f)));
		}

		#endregion
	}
}