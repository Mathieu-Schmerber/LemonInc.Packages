using UnityEditor;
using UnityEngine;

namespace LemonInc.Tools.PackageHandler
{
	/// <summary>
	/// The styles.
	/// </summary>
	public static class Styles
	{
		/// <summary>
		/// Gets the background.
		/// </summary>
		/// <param name="color">The color.</param>
		/// <returns></returns>
		public static Texture2D GetBackground(Color color)
		{
			var texture = new Texture2D(1, 1);

			texture.SetPixel(0, 0, color);
			texture.Apply();
			return texture;
		}

		/// <summary>
		/// The banner.
		/// </summary>
		public static GUIStyle Banner = new()
		{
			fixedHeight = 50,
			margin = new RectOffset(10, 10, 10, 10)
		};

		/// <summary>
		/// The title.
		/// </summary>
		public static GUIStyle Title = new GUIStyle(EditorStyles.boldLabel);

		public static class Package
		{
			public static GUIStyle Button = new GUIStyle(EditorStyles.miniButton)
			{
				fixedWidth = 70
			};
		}
	}
}