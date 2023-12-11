using UnityEngine;

namespace LemonInc.Core.Utilities.Graph
{
	/// <summary>
	/// Describes a node.
	/// </summary>
	public interface INode
	{
		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public string Id { get; }

		/// <summary>
		/// Gets or sets the alias.
		/// </summary>
		/// <value>
		/// The alias.
		/// </value>
		public string Alias { get; set; }

		/// <summary>
		/// Gets or sets the position on the graph.
		/// </summary>
		/// <value>
		/// The position.
		/// </value>
		public Vector2 Position { get; set; }
	}
}
