using LemonInc.Tools.GdPanel.Interfaces;
using UnityEngine;

namespace LemonInc.Tools.GdPanel.Models
{
	/// <summary>
	/// SidebarController element.
	/// </summary>
	/// <seealso cref="ISidebarElement" />
	public class SidebarElement : ISidebarElement
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
		public SidebarElementType Type => SidebarElementType.ELEMENT;

		/// <summary>
		/// Initializes a new instance of the <see cref="SidebarElement"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public SidebarElement(int id) => Id = id;
	}
}