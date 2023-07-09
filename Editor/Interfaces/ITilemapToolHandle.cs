using System;
using System.Collections.Generic;
using UnityEngine;

namespace LemonInc.Tools.Tilemap.Editor.Interfaces
{
	public interface ITilemapToolHandle
	{
		public Action<IEnumerable<Vector3Int>> Select { get; set; }
		public Action<IEnumerable<Vector3Int>> Draw { get; set; }
		public Action<IEnumerable<Vector3Int>> Erase { get; set; }

		public void OnTileHover(Vector3Int tile);
		public void OnTileDown(Vector3Int tile);
		public void OnTileDragged(Vector3Int tile);
		public void OnTileUp(Vector3Int tile);
	}
}