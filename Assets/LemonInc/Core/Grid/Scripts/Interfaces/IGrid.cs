using UnityEngine;

namespace LemonInc.Core.Grid.Interfaces
{
	/// <summary>
	/// Defines a grid.
	/// </summary>
	public interface IGrid
	{
		/// <summary>
		/// Gets the origin.
		/// </summary>
		/// <value>
		/// The origin.
		/// </value>
		public Vector3 Origin { get; }

		/// <summary>
		/// Gets the size of the cell.
		/// </summary>
		/// <value>
		/// The size of the cell.
		/// </value>
		public Vector3 CellSize { get; }
	}
}