using UnityEngine;

namespace LemonInc.Core.Utilities
{
	/// <summary>
	/// Color utilities.
	/// </summary>
	public static class ColorUtilities
	{
		/// <summary>
		/// Randoms a color.
		/// </summary>
		/// <param name="alpha">The alpha.</param>
		/// <returns>The <see cref="Color32"/>.</returns>
		public static Color32 RandomColor(int alpha = 255)
		{
			System.Random random = new();

			return new Color32(
				(byte)random.Next(0, 255),
				(byte)random.Next(0, 255),
				(byte)random.Next(0, 255),
				(byte)alpha
			);
		}

		/// <summary>
		/// Randoms a color.
		/// </summary>
		/// <param name="seed">The seed.</param>
		/// <param name="alpha">The alpha.</param>
		/// <returns>The <see cref="Color32"/>.</returns>
		public static Color32 RandomColor(string seed, int alpha = 255)
		{
			System.Random random = new(seed.GetHashCode());

			return new Color32(
				(byte)random.Next(0, 255),
				(byte)random.Next(0, 255),
				(byte)random.Next(0, 255),
				(byte)alpha
			);
		}
	}
}
