using LemonInc.Core.Utilities;
using UnityEngine;

namespace LemonInc.Tools.Tilemap.Data
{
	/// <summary>
	/// Stores tilemap data.
	/// </summary>
	[CreateAssetMenu(menuName = "Lemon Inc/Tilemap/Tilemap")] // TODO: tmp, create from editor or smthg
	public class TilemapData : ScriptableObject
	{
		/// <summary>
		/// Dictionary storing tiles by their 3D grid position.
		/// </summary>
		public class TileDictionary : SerializedDictionary<Vector3Int, Tile> { }

		[HideInInspector] public TileDictionary Tiles;

		private void OnValidate()
		{
			if (Tiles == null)
				Tiles = new();
		}
	}
}