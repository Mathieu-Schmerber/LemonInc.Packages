using System;
using System.Collections.Generic;
using LemonInc.Tools.Tilemap.Editor.Interfaces;
using UnityEngine;

namespace LemonInc.Tools.Tilemap.Editor.Tools
{
	public class SquareEraserToolHandle : ITilemapToolHandle
	{
		private Vector3Int _firstPoint;
		private Vector3Int _secondPoint;

		private bool _down;

		public Action<IEnumerable<Vector3Int>> Select { get; set; }
		public Action<IEnumerable<Vector3Int>> Draw { get; set; }
		public Action<IEnumerable<Vector3Int>> Erase { get; set; }

		public SquareEraserToolHandle(Action<IEnumerable<Vector3Int>> select, Action<IEnumerable<Vector3Int>> draw, Action<IEnumerable<Vector3Int>> erase)
		{
			Select = select;
			Draw = draw;
			Erase = erase;
		}

		public void OnTileDown(Vector3Int tile)
		{
			_firstPoint = tile;
			_down = true;
		}

		public void OnTileDragged(Vector3Int tile)
		{
			_secondPoint = tile;
		}

		public void OnTileHover(Vector3Int tile)
		{
			if (!_down)
			{
				_firstPoint = tile;
				_secondPoint = tile;
			}

			Select?.Invoke(GetSelection());
		}

		public void OnTileUp(Vector3Int tile)
		{
			_down = false;
			Erase?.Invoke(GetSelection());
			_firstPoint = tile;
			_secondPoint = tile;
		}

		private IEnumerable<Vector3Int> GetSelection()
		{
			if (_firstPoint == _secondPoint)
				return new Vector3Int[1] { _firstPoint };

			var max = new Vector3Int(Mathf.Max(_firstPoint.x, _secondPoint.x), Mathf.Max(_firstPoint.y, _secondPoint.y), Mathf.Max(_firstPoint.z, _secondPoint.z));
			var min = new Vector3Int(Mathf.Min(_firstPoint.x, _secondPoint.x), Mathf.Min(_firstPoint.y, _secondPoint.y), Mathf.Min(_firstPoint.z, _secondPoint.z));
			var selection = new List<Vector3Int>();

			for (int x = min.x; x <= max.x; x++)
				for (int y = min.y; y <= max.y; y++)
					for (int z = min.z; z <= max.z; z++)
						selection.Add(new Vector3Int(x, y, z));

			return selection;
		}
	}
}