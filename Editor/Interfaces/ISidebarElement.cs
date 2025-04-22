using LemonInc.Tools.Panels.Controllers;
using LemonInc.Tools.Panels.Models;
using UnityEngine;

namespace LemonInc.Tools.Panels.Interfaces
{
	/// <summary>
	/// Design element, belongs to <see cref="SidebarEntry"/>
	/// </summary>
	public interface ISidebarElement
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the display name.
		/// </summary>
		/// <value>
		/// The display name.
		/// </value>
		public string DisplayName { get; set; }

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		/// <value>
		/// The path.
		/// </value>
		public string Path { get; set; }

		/// <summary>
		/// Gets or sets the object.
		/// </summary>
		/// <value>
		/// The object.
		/// </value>
		public Object Object { get; set; }

		/// <summary>
		/// Gets or sets whether the element is empty, only applicable to <see cref="SidebarElementType.GROUP"/>
		/// </summary>
		public bool Empty { get; set; }

		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public SidebarElementType Type { get; }
	}
}