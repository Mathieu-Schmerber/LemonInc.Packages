using System;
using System.Collections.Generic;
using LemonInc.Tools.Tilemap.Editor.Interfaces;
using UnityEngine;

namespace LemonInc.Tools.Tilemap.Editor.Tools
{
	public class BrushToolHandle : ITilemapToolHandle
	{
		public Action<IEnumerable<Vector3Int>> Select { get; set; }
		public Action<IEnumerable<Vector3Int>> Draw { get; set; }
		public Action<IEnumerable<Vector3Int>> Erase { get; set; }

		public BrushToolHandle(Action<IEnumerable<Vector3Int>> select, Action<IEnumerable<Vector3Int>> draw, Action<IEnumerable<Vector3Int>> erase)
		{
			Select = select;
			Draw = draw;
			Erase = erase;
		}

		public void OnTileDown(Vector3Int tile)
		{
			Draw?.Invoke(new Vector3Int[1] { tile });
		}

		public void OnTileDragged(Vector3Int tile)
		{
			Draw?.Invoke(new Vector3Int[1] { tile });
		}

		public void OnTileHover(Vector3Int tile)
		{
			Select?.Invoke(new Vector3Int[1] { tile });
		}

		public void OnTileUp(Vector3Int tile) {}
	}
}