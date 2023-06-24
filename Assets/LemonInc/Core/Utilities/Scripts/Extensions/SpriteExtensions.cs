using UnityEngine;

namespace LemonInc.Core.Utilities.Extensions
{
	/// <summary>
	/// Extensions for <see cref="Sprite"/>
	/// </summary>
	public static class SpriteExtensions
	{
		/// <summary>
		/// Converts a sprite to a texture.
		/// </summary>
		/// <param name="sprite">The sprite to convert.</param>
		/// <returns>The converted texture.</returns>
		public static Texture2D ToTexture(this Sprite sprite)
		{
			var tex = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
			var pixels = sprite.texture.GetPixels(
				(int)sprite.textureRect.x,
				(int)sprite.textureRect.y,
				(int)sprite.textureRect.width,
				(int)sprite.textureRect.height);

			tex.SetPixels(pixels);
			tex.Apply();
			return tex;
		}
	}
}