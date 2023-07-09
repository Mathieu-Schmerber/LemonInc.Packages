using UnityEngine;

namespace LemonInc.Editor.Utilities.Tooltip
{
	/// <summary>
	/// Tooltip attribute to be displayed in editor.
	/// </summary>
	/// <seealso cref="UnityEngine.PropertyAttribute" />
	public class Tooltip : PropertyAttribute
	{
		/// <summary>
		/// Gets or sets the content.
		/// </summary>
		/// <value>
		/// The content.
		/// </value>
		public string Content { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Tooltip"/> class.
		/// </summary>
		/// <param name="tooltipText">The tooltip text.</param>
		public Tooltip(string tooltipText)
		{
			Content = tooltipText;
		}
	}
}