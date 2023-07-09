using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Grid.Extensions;
using LemonInc.Core.Grid.Interfaces;
using LemonInc.Tools.Tilemap.Data;
using UnityEngine;

namespace LemonInc.Tools.Tilemap
{
    /// <summary>
    /// Implementation of <see cref="IGrid"/> for tilemaps.
    /// </summary>
    public class Tilemap : MonoBehaviour, IGrid
    {
        public TilemapData Data;
		public TileData Selected;
		public List<TileData> Palette;
		[SerializeField] public Vector3 _cellSize = Vector3.one;

		private void OnValidate()
		{
			Palette ??= new();
		}

		#region Grid

		/// <inheritdoc/>
		public Vector3 Origin => transform.position;

		/// <inheritdoc/>
		public Vector3 CellSize => _cellSize;

		/// <summary>
		/// Snaps a world position to the grid.
		/// </summary>
		/// <param name="worldPos">The world position to be snapped.</param>
		/// <returns>The snapped world position.</returns>
		public Vector3 SnapToGrid(Vector3 worldPos)
		{
			Vector3Int floored = this.ToGridPos(worldPos);

			return this.ToWorldPos(floored);
		}

		#endregion

		/// <summary>
		/// Gets a <see cref="GameObject"/> by grid position.
		/// </summary>
		/// <param name="gridPosition">The grid position to fetch.</param>
		/// <returns>The instance at the given position or null.</returns>
		public GameObject GetInstanceAt(Vector3Int gridPosition)
		{
			Vector3 position = this.ToWorldPos(gridPosition);

			for (int i = 0; i < transform.childCount; i++)
			{
				if (transform.GetChild(i).position == position)
					return transform.GetChild(i).gameObject;
			}
			return null;
		}

		/// <summary>
		/// Gets a <see cref="Tile"/> by grid position.
		/// </summary>
		/// <param name="gridPosition">The grid position to fetch.</param>
		/// <returns>The tile at the given position or null.</returns>
		public Tile GetTile(Vector3Int gridPosition)
		{
			if (Data.Tiles.TryGetValue(gridPosition, out Tile result))
				return result;
			return null;
		}

		/// <summary>
		/// Places a tile at the given position.
		/// </summary>
		/// <param name="gridPosition">The position where to place the tile.</param>
		/// <param name="tile">The <see cref="TileData"/> to be placed.</param>
		/// <returns>The newly placed <see cref="Tile"/>.</returns>
		public Tile SetTile(Vector3Int gridPosition, TileData tile)
		{
			Tile current;

			if (Data.Tiles.TryGetValue(gridPosition, out current))
			{
				if (current.Data == tile)
				{
					current.Refresh(this, gridPosition);
					return current;
				}
			}
			else
			{
				current = new Tile();
				Data.Tiles.Add(gridPosition, current);
			}

			current.Data = tile;
			current.Refresh(this, gridPosition);
			return current;
		}

		/// <summary>
		/// Places multiple tiles at the given grid positions;
		/// </summary>
		/// <param name="gridPositions">The positions where to place the tiles.</param>
		/// <param name="tile">The <see cref="TileData"/> to be placed.</param>
		/// <returns>The placed tiles</returns>
		public IList<Tile> SetTiles(IEnumerable<Vector3Int> gridPositions, TileData tile)
			=> gridPositions.Select(x => SetTile(x, tile)).ToList();
	}
}