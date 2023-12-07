﻿using UnityEditor;

namespace LemonInc.Editor.Utilities.Configuration.Extensions
{
	/// <summary>
	/// Configuration asset extension methods.
	/// </summary>
	public static class ConfigurationAssetExtensions
	{
		/// <summary>
		/// Saves the configuration.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="config">The configuration.</param>
		public static void Save(this ConfigurationAsset config)
		{
			if (config == null)
				return;

			EditorUtility.SetDirty(config);
			AssetDatabase.SaveAssetIfDirty(config);
		}
	}
}
