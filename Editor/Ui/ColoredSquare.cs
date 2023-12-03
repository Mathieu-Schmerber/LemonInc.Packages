using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Ui
{
	/// <summary>
	/// Square visual element.
	/// </summary>
	/// <seealso cref="UnityEngine.UIElements.VisualElement" />
	public class ColoredSquare : VisualElement
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ColoredSquare"/> class.
		/// </summary>
		/// <param name="color">The color.</param>
		public ColoredSquare(Color color)
		{
			style.backgroundColor = new StyleColor(color);
			AddToClassList("square");
		}
	}
}