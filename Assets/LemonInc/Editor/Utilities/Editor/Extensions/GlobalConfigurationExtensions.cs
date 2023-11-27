using Sirenix.Utilities;
using UnityEditor;

namespace LemonInc.Editor.Utilities.Extensions
{
	/// <summary>
	/// Global configuration extensions.
	/// </summary>
	public static class GlobalConfigurationExtensions
	{
		/// <summary>
		/// Saves the configuration.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="config">The configuration.</param>
		public static void Save<T>(this GlobalConfig<T> config)
			where T : GlobalConfig<T>, new()
		{
			EditorUtility.SetDirty(config);
			AssetDatabase.SaveAssetIfDirty(config);
		}
	}
}
