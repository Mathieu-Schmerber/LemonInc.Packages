using UnityEditor;
using UnityEngine;

namespace LemonInc.Editor.Utilities.Extensions
{
	/// <summary>
	/// Object extension methods.
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Saves the object.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="asset">The asset.</param>
		public static void Save<T>(this T asset)
			where T : Object
		{
			if (asset == null)
				return;

			EditorUtility.SetDirty(asset);
			AssetDatabase.SaveAssetIfDirty(asset);
		}

		/// <summary>
		/// Gets the asset path.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="asset">The asset.</param>
		/// <returns>The asset path, from asset folder.</returns>
		public static string GetPath<T>(this T asset)
			where T : Object
		{
			return AssetDatabase.GetAssetPath(asset);
		}
	}
}
