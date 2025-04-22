using System.Collections.Generic;
using UnityEditor;

namespace LemonInc.Core.Utilities.Editor.Helpers
{
    /// <summary>
    /// Asset helper.
    /// </summary>
    public static class AssetHelper
    {
        /// <summary>
        /// Finds the assets of a specific type, optionally limited to a folder.
        /// </summary>
        /// <typeparam name="T">The asset type.</typeparam>
        /// <param name="folder">Optional folder path to search in (relative to Assets/).</param>
        /// <returns>The found assets.</returns>
        public static IList<T> FindAssetsByType<T>(string folder = null) where T : UnityEngine.Object
        {
            var assets = new List<T>();
            string[] searchInFolders = string.IsNullOrEmpty(folder) ? null : new[] { folder };

            var guidList = AssetDatabase.FindAssets($"t:{typeof(T)}", searchInFolders);

            foreach (var guid in guidList)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);

                if (asset != null)
                    assets.Add(asset);
            }

            return assets;
        }
    }
}