using UnityEngine;

namespace LemonInc.Core.Utilities.Extensions
{
	/// <summary>
	/// <see cref="Color"/> extensions.
	/// </summary>
	public static class ColorExtensions
	{
		/// <summary>
		/// Gets the color with the provided alpha.
		/// </summary>
		/// <param name="color">The color.</param>
		/// <param name="alpha">The alpha.</param>
		/// <returns>The <see cref="Color"/>.</returns>
		public static Color WithAlpha(this Color color, float alpha) => new(color.r, color.g, color.b, alpha);

		/// <summary>
		/// Gets the color with the provided red component.
		/// </summary>
		/// <param name="color">The color.</param>
		/// <param name="red">The red value.</param>
		/// <returns>The <see cref="Color"/>.</returns>
		public static Color WithRed(this Color color, float red) => new(red, color.g, color.b, color.a);

		/// <summary>
		/// Gets the color with the provided green component.
		/// </summary>
		/// <param name="color">The color.</param>
		/// <param name="green">The green value.</param>
		/// <returns>The <see cref="Color"/>.</returns>
		public static Color WithGreen(this Color color, float green) => new(color.r, green, color.b, color.a);

		/// <summary>
		/// Gets the color with the provided blue component.
		/// </summary>
		/// <param name="color">The color.</param>
		/// <param name="blue">The blue value.</param>
		/// <returns>The <see cref="Color"/>.</returns>
		public static Color WithBlue(this Color color, float blue) => new(color.r, color.g, blue, color.a);

		/// <summary>
		/// Gets the color with optional modifications to its components.
		/// </summary>
		/// <param name="color">The color.</param>
		/// <param name="r">The optional red value.</param>
		/// <param name="g">The optional green value.</param>
		/// <param name="b">The optional blue value.</param>
		/// <param name="a">The optional alpha value.</param>
		/// <returns>The <see cref="Color"/>.</returns>
		public static Color With(this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
		{
			return new Color(
				r ?? color.r,
				g ?? color.g,
				b ?? color.b,
				a ?? color.a
			);
		}
	}
}