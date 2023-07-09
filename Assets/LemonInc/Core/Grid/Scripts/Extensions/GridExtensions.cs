using LemonInc.Core.Grid.Interfaces;
using UnityEngine;

namespace LemonInc.Core.Grid.Extensions
{
	/// <summary>
	/// Extensions for <see cref="IGrid"/>.
	/// </summary>
	public static class GridExtensions
	{
		/// <summary>
		/// Converts world position to grid position
		/// </summary>
		/// <param name="worldPos">The world position to be converted.</param>
		/// <param name="grid">The <see cref="IGrid"/>.</param>
		/// <returns>The converted grid position.</returns>
		public static Vector3Int ToGridPos(this IGrid grid, Vector3 worldPos)
		{
			var position = worldPos - grid.Origin;
			var x = Mathf.RoundToInt(position.x / grid.CellSize.x);
			var y = Mathf.RoundToInt(position.y / grid.CellSize.y);
			var z = Mathf.RoundToInt(position.z / grid.CellSize.z);

			return new Vector3Int(x, y, z);
		}

		/// <summary>
		/// Converts grid position to world position
		/// </summary>
		/// <param name="gridPos">The grid position to be converted.</param>
		/// <param name="grid">The <see cref="IGrid"/>.</param>
		/// <returns>The converted world position.</returns>
		public static Vector3 ToWorldPos(this IGrid grid, Vector3Int gridPos)
		{
			var gridOffset = grid.Origin;
			var cellSize = grid.CellSize;

			return new Vector3(gridPos.x * cellSize.x, gridPos.y * cellSize.y, gridPos.z * cellSize.z) + gridOffset;
		}
	}
}