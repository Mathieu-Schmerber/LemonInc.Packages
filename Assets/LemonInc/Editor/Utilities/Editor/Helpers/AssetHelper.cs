using System;
using System.Collections.Generic;
using UnityEditor;

namespace LemonInc.Editor.Utilities.Helpers
{
	/// <summary>
	/// Asset helper.
	/// </summary>
	public static class AssetHelper
	{
		/// <summary>
		/// Finds the type of the assets by type.
		/// </summary>
		/// <typeparam name="T">The asset type.</typeparam>
		/// <returns>The found assets.</returns>
		public static IList<T> FindAssetsByType<T>() where T : UnityEngine.Object
        {
            var assets = new List<T>();
            var guidList = AssetDatabase.FindAssets($"t:{typeof(T)}");

            foreach (var guid in guidList)
            {
	            var assetPath = AssetDatabase.GUIDToAssetPath(guid);
	            var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                
	            if (asset != null)
		            assets.Add(asset);
            }

            return assets;
        }

		/// <summary>
		/// Converts a full path to an asset path.
		/// </summary>
		/// <param name="fullPath">The full path.</param>
		/// <returns>The asset path.</returns>
		public static string ToAssetPath(this string fullPath)
		{
            if (string.IsNullOrEmpty(fullPath))
                return string.Empty;

            var index = fullPath.IndexOf("Assets", StringComparison.Ordinal);
            return fullPath.Remove(0, index);
		}
    }
}