using LemonInc.Core.Utilities;
using UnityEngine;

namespace LemonInc.Tools.Tilemap.Data.TileProperties
{
	/// <summary>
	/// Define tile properties.
	/// </summary>
	[System.Serializable]
	public class TileProperty 
	{
		public enum PatternRotation
		{
			Never, _90, _180
		}

		public enum MirrorOutcome
		{
			Never, X, Y, Z, Xy, Xz, Yz, Xyz
		}

		[System.Serializable]
		public class NeighborTiling : SerializedDictionary<Vector2Int, TileData> { }

		public NeighborTiling Neighboring;
		public GameObject Outcome;

		public PatternRotation Rotate;
		public bool RotateTile;
		public MirrorOutcome Mirror;
		public GameObject[] Random;

		public TileProperty(GameObject outcome = null)
		{
			Outcome = outcome;
			Neighboring = new NeighborTiling
			{
				{ Vector2Int.up, null },
				{ Vector2Int.down, null },
				{ Vector2Int.left, null },
				{ Vector2Int.right, null },
				{ Vector2Int.up + Vector2Int.left, null },
				{ Vector2Int.up + Vector2Int.right, null },
				{ Vector2Int.down + Vector2Int.left, null },
				{ Vector2Int.down + Vector2Int.right, null },
			};
		}
	}
}