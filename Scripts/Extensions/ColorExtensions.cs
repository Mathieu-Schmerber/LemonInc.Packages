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
	}
}
