using System.IO;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Editor.Utilities.Configuration
{
	public class ConfigurationAsset<T> : ScriptableObject
		where T : ScriptableObject
	{
		private static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null)
					CreateAndLoad();
				return _instance;
			}
		}

		protected ConfigurationAsset()
		{
			if (_instance != null)
				Debug.LogError("ConfigurationAsset already exists. Did you query the singleton in a constructor?");
			else
				_instance = this as T;
		}

		private static void CreateAndLoad()
		{
			string filePath = GetFilePath();
			if (!string.IsNullOrEmpty(filePath))
				_instance = AssetDatabase.LoadAssetAtPath<T>(filePath);

			if (_instance == null)
				CreateInstanceAndAsset();
		}

		private static void CreateInstanceAndAsset()
		{
			_instance = ScriptableObject.CreateInstance<T>();

			// Save the asset physically
			string filePath = GetFilePath();
			string directoryName = Path.GetDirectoryName(filePath);
			Directory.CreateDirectory(directoryName);

			AssetDatabase.CreateAsset(_instance, filePath);
			AssetDatabase.SaveAssets();
		}

		private static void SaveInstance(ConfigurationAsset<T> instance)
		{
			if (instance == null)
			{
				Debug.LogError("Cannot save ConfigurationAsset: no instance!");
			}
			else
			{
				EditorUtility.SetDirty(instance);
				AssetDatabase.SaveAssetIfDirty(instance);
			}
		}

		public void Save() => SaveInstance(this);

		protected static string GetFilePath()
		{
			foreach (object customAttribute in typeof(T).GetCustomAttributes(true))
			{
				if (customAttribute is ConfigurationAssetAttribute filepathAttribute)
					return Path.Combine("Assets", filepathAttribute.Path, $"{typeof(T).Name}.asset");
			}
			return string.Empty;
		}
	}
}
