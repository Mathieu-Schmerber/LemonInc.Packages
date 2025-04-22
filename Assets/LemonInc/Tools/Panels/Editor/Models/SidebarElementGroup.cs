using LemonInc.Tools.Panels.Interfaces;
using UnityEngine;

namespace LemonInc.Tools.Panels.Models
{
	/// <summary>
	/// SidebarController element group.
	/// </summary>
	/// <seealso cref="ISidebarElement" />
	public class SidebarElementGroup : ISidebarElement
	{
		/// <inheritdoc/>
		public int Id { get; set; }

		/// <inheritdoc/>
		public string DisplayName { get; set; }

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		/// <value>
		/// The path.
		/// </value>
		public string Path { get; set; }

		/// <inheritdoc/>
		public Object Object { get; set; }

		/// <inheritdoc/>
		public bool Empty { get; set; }

		/// <inheritdoc/>
		public SidebarElementType Type => SidebarElementType.GROUP;

		/// <summary>
		/// Initializes a new instance of the <see cref="SidebarElementGroup"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public SidebarElementGroup(int id) => Id = id;
	}
}