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
			if (_instance == null)
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

		public static string GetFilePath()
		{
			foreach (object customAttribute in typeof(T).GetCustomAttributes(true))
			{
				if (customAttribute is ConfigurationAssetAttribute filepathAttribute)
					return Path.Combine("Assets", filepathAttribute.Path, $"{typeof(T).Name}.asset");
			}
			return string.Empty;
		}

		public static string GetFolderPath()
		{
			foreach (object customAttribute in typeof(T).GetCustomAttributes(true))
			{
				if (customAttribute is ConfigurationAssetAttribute filepathAttribute)
					return Path.Combine("Assets", filepathAttribute.Path);
			}
			return string.Empty;
		}
	}
}
