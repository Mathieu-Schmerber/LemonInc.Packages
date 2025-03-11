using System.Linq;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Extensions
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
		
		/// <summary>
		/// Creates a child scriptable object of a given parent.
		/// </summary>
		/// <param name="parent">The parent asset.</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>The created scriptable.</returns>
		public static T CreateChildScriptable<T>(this Object parent) where T : ScriptableObject
		{
			var child = ScriptableObject.CreateInstance<T>();
			AssetDatabase.AddObjectToAsset(child, parent);
			AssetDatabase.SaveAssets();
			return child;
		}
		
		/// <summary>
		/// Retrieves all child assets of the specified type that are associated with the given parent asset.
		/// </summary>
		/// <typeparam name="T">The type of ScriptableObject to retrieve.</typeparam>
		/// <param name="parent">The parent asset.</param>
		/// <returns>An array of child assets of type T, or null if the parent asset has no path.</returns>
		public static T[] GetChildAssetsOfType<T>(this Object parent) where T : ScriptableObject
		{
			var path = parent.GetPath();
			if (string.IsNullOrEmpty(path)) 
				return null;

			return AssetDatabase.LoadAllAssetsAtPath(path)
				.OfType<T>()
				.Where(asset => asset != parent)
				.ToArray();
		}
		
		/// <summary>
		/// Retrieves the first child asset of the specified type that is associated with the given parent asset.
		/// </summary>
		/// <typeparam name="T">The type of ScriptableObject to retrieve.</typeparam>
		/// <param name="parent">The parent asset.</param>
		/// <returns>The first child asset of type T, or null if none are found.</returns>
		public static T GetChildAssetOfType<T>(this Object parent) where T : ScriptableObject
		{
			var path = parent.GetPath();
			if (string.IsNullOrEmpty(path)) 
				return null;

			return AssetDatabase.LoadAllAssetsAtPath(path).FirstOrDefault(x => x.GetType() == typeof(T)) as T;
		}
	}
}
