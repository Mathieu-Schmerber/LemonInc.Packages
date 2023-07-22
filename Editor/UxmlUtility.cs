using System.IO;
using UnityEditor;
using UnityEngine.UIElements;

namespace LemonInc.Editor.Uxml
{
	/// <summary>
	/// Uxml utility.
	/// </summary>
	internal static class UxmlUtility
	{
		/// <summary>
		/// Determines whether the specified path is uxml.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="uxmlAsset">The uxml asset.</param>
		/// <returns>
		///   <c>true</c> if the specified path is uxml; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsUxml(string path, out VisualTreeAsset uxmlAsset)
		{
			uxmlAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);

			return Path.GetExtension(path).Equals(".uxml");
		}
	}
}