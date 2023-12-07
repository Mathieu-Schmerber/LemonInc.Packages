using System.IO;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Editor.Utilities.Configuration
{
	/// <summary>
	/// Loads configuration.
	/// </summary>
	public static class ConfigurationLoader
	{
		/// <summary>
		/// Gets the configuration.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="path">The path.</param>
		/// <returns>The configuration or null if it does not exist.</returns>
		private static T GetConfiguration<T>(string path)
			where T : Object, IConfiguration
			=> Application.isPlaying ? Resources.Load<T>(path) : AssetDatabase.LoadAssetAtPath<T>(path);

		/// <summary>
		/// Creates the configuration.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="path">The path.</param>
		/// <returns>The created configuration.</returns>
		private static T CreateConfiguration<T>(string path)
			where T : ConfigurationAsset
		{
			var created = ScriptableObject.CreateInstance<T>();
			var directory = Path.GetDirectoryName(path);
			Directory.CreateDirectory(directory);

			AssetDatabase.CreateAsset(created, path);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
			return created;
		}

		/// <summary>
		/// Loads the configuration.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assetPath">The path.</param>
		/// <returns>The configuration or null.</returns>
		public static T LoadConfiguration<T>(string assetPath)
			where T : ConfigurationAsset
		{
			var path = Path.Combine("Assets", assetPath);
			var result = GetConfiguration<T>(path);
			if (result == null)
			{
				result = CreateConfiguration<T>(path);
				result.OnCreated();
			}

			result.OnLoaded();
			return result;
		}
	}
}
