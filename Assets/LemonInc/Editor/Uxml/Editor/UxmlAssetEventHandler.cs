using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Editor.Utilities.Events;
using LemonInc.Editor.Utilities.Extensions;
using UnityEditor;

namespace LemonInc.Editor.Uxml
{
	/// <summary>
	/// Uxml asset event handler.
	/// </summary>
	/// <seealso cref="UnityEditor.AssetPostprocessor" />
	internal class UxmlAssetEventHandler
	{
		/// <summary>
		/// The watcher list.
		/// </summary>
		private static readonly IDictionary<string, FileSystemWatcher> WatcherList = new Dictionary<string, FileSystemWatcher>();

		/// <summary>
		/// Called when [load].
		/// </summary>
		[InitializeOnLoadMethod]
		public static void OnLoad()
		{
			EditorEvents.Asset.OnAssetImported -= OnAssetCreated;
			EditorEvents.Asset.OnAssetMoved -= OnAssetMoved;
			EditorEvents.Asset.OnAssetDeleted -= OnAssetDeleted;

			EditorEvents.Asset.OnAssetImported += OnAssetCreated;
			EditorEvents.Asset.OnAssetMoved += OnAssetMoved;
			EditorEvents.Asset.OnAssetDeleted += OnAssetDeleted;

			CleanupConfig();
			WatchUxmls();
		}

		/// <summary>
		/// Called when [asset created].
		/// </summary>
		/// <param name="assetPath">The assetPath.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		private static void OnAssetCreated(string assetPath)
		{
			if (!UxmlUtility.IsUxml(assetPath, out _))
				return;

			var creation = File.GetCreationTime(assetPath);
			var timeOffset = DateTime.Now - creation;
			if (timeOffset.Minutes > 5)
				// Ensure creation within project from user actions
				return;

			if (!UxmlAssetConfiguration.Instance.References.ContainsKey(assetPath))
			{
				OnUxmlCreated(assetPath);
			}
			else
			{
				UxmlLogger.Log($"Asset path '{assetPath}' already in config.");
			}
		}

		/// <summary>
		/// Called when [asset moved].
		/// </summary>
		/// <param name="oldAssetPath">The oldAssetPath.</param>
		/// <param name="newAssetPath">The newAssetPath.</param>
		private static void OnAssetMoved(string oldAssetPath, string newAssetPath)
		{
			if (newAssetPath.Contains("Assets/Packages") || !UxmlUtility.IsUxml(oldAssetPath, out _))
				return;
			
			if (!UxmlAssetConfiguration.Instance.References.TryGetValue(oldAssetPath, out var uxmlAssetDefinition))
			{
				UxmlLogger.Log($"Asset path '{oldAssetPath}' not found in config.");
				DeleteWatcherEntryIfExists(oldAssetPath);
				return;
			}

			uxmlAssetDefinition.AssetPath = newAssetPath;
			OnUxmlMoved(oldAssetPath, uxmlAssetDefinition);
		}

		/// <summary>
		/// Called when [asset deleted].
		/// </summary>
		/// <param name="assetPath">The asset path.</param>
		private static void OnAssetDeleted(string assetPath)
		{
			if (assetPath.Contains("Assets/Packages") || !UxmlUtility.IsUxml(assetPath, out _))
				return;

			if (UxmlAssetConfiguration.Instance.References.ContainsKey(assetPath))
				OnUxmlDeleted(assetPath);
			else
				UxmlLogger.Log($"Asset path '{assetPath}' not found in config.");
		}
		
		/// <summary>
		/// Watches the uxml files.
		/// </summary>
		public static void WatchUxmls()
		{
			for (var i = 0; i < WatcherList.Keys.Count; i++)
				DeleteWatcherEntryIfExists(WatcherList.Keys.ElementAt(i));
			WatcherList.Clear();

			foreach (var (assetPath, _) in UxmlAssetConfiguration.Instance.References)
				AddWatcherEntryIfNotExist(assetPath);
		}

		/// <summary>
		/// Cleans up the configuration.
		/// </summary>
		private static void CleanupConfig()
		{
			foreach (var assetPath in UxmlAssetConfiguration.Instance.References.Keys.ToList())
			{
				var fullPath = Path.GetFullPath(assetPath);
				if (File.Exists(fullPath))
					continue;

				UxmlLogger.Log($"Cleaning up '{assetPath}'.");
				OnUxmlDeleted(assetPath);
			}
		}

		/// <summary>
		/// Adds the watcher entry if not exist.
		/// </summary>
		/// <param name="assetPath">The asset path.</param>
		private static void AddWatcherEntryIfNotExist(string assetPath)
		{
			if (WatcherList.ContainsKey(assetPath))
				return;

			UxmlLogger.Log($"Creating watcher for '{assetPath}'...");
			var watcher = CreateFileWatcher(assetPath);
			if (watcher != null)
			{
				UxmlLogger.Log($"Watching '{assetPath}' !");
				WatcherList.Add(assetPath, watcher);
			}
		}

		/// <summary>
		/// Deletes the watcher entry if exists.
		/// </summary>
		/// <param name="assetPath">The asset path.</param>
		private static void DeleteWatcherEntryIfExists(string assetPath)
		{
			if (!WatcherList.TryGetValue(assetPath, out var watcher)) 
				return;

			watcher.Changed -= OnFileChanged;
			watcher.Dispose();
			WatcherList.Remove(assetPath);
		}

		/// <summary>
		/// Creates the file watcher.
		/// </summary>
		/// <param name="assetPath">The asset path.</param>
		public static FileSystemWatcher CreateFileWatcher(string assetPath)
		{
			var fullPath = Path.GetFullPath(assetPath);
			if (!File.Exists(fullPath))
			{
				UxmlLogger.Log($"Path '{fullPath}' does not exist.");
				return null;
			}

			var directory = Path.GetDirectoryName(fullPath);
			var watcher = new FileSystemWatcher();

			watcher.Path = directory;
			watcher.NotifyFilter = NotifyFilters.LastAccess 
			                       | NotifyFilters.LastWrite;

			watcher.Filter = $"{Path.GetFileNameWithoutExtension(fullPath)}.uxml";
			watcher.Changed += OnFileChanged;
			watcher.EnableRaisingEvents = true;

			return watcher;
		}
		
		/// <summary>
		/// On File changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
		private static void OnFileChanged(object sender, FileSystemEventArgs e)
		{
			if (!UxmlAssetConfiguration.Instance.References.TryGetValue(e.FullPath.ToAssetPath(), out var uxmlAssetDefinition))
			{
				UxmlLogger.Log($"Asset path '{e.FullPath.ToAssetPath()}' not found in config.");
				DeleteWatcherEntryIfExists(e.FullPath.ToAssetPath());
				return;
			}

			OnUxmlSaved(uxmlAssetDefinition);
		}

		/// <summary>
		/// Gets the name of the reference class.
		/// </summary>
		/// <param name="uxmlName">Name of the uxml.</param>
		/// <param name="folderAssetPath">The folderAssetPath.</param>
		/// <returns></returns>
		private static string GetReferenceClassName(string uxmlName, string folderAssetPath)
			=> $"{Path.Combine(folderAssetPath, uxmlName.ToPascalCase()).ToAssetPath()}Reference.cs";

		/// <summary>
		/// Called when [uxml created].
		/// </summary>
		/// <param name="uxmlPath">The uxml asset path.</param>
		private static void OnUxmlCreated(string uxmlPath)
		{
			UxmlLogger.Log($"Uxml created '{uxmlPath}'.");

			var uxmlFolder = Path.GetDirectoryName(uxmlPath);
			var uxmlName = Path.GetFileNameWithoutExtension(uxmlPath);
			var folder = EditorUtility.OpenFolderPanel("Select the reference class folder", uxmlFolder, "");
			if (string.IsNullOrEmpty(folder))
				return;

			var uxmlDefinition = new UxmlAssetDefinition()
			{
				AssetPath = uxmlPath,
				ReferenceClass = GetReferenceClassName(uxmlName, folder)
			};

			UxmlAssetConfiguration.Instance.References.Add(uxmlPath, uxmlDefinition);
			UxmlAssetConfiguration.Instance.Save();

			UxmlReferenceCodeGenerator.GenerateCode(uxmlDefinition, createDirectory: false);

			// Update watcher
			AddWatcherEntryIfNotExist(uxmlDefinition.AssetPath);
		}

		/// <summary>
		/// Called when [uxml saved].
		/// </summary>
		/// <param name="uxml">The uxml.</param>
		private static void OnUxmlSaved(UxmlAssetDefinition uxml)
		{
			UxmlLogger.Log($"OnUxmlSaved '{uxml.AssetPath}'");

			if (string.IsNullOrEmpty(uxml.ReferenceClass))
				return;
			UxmlLogger.Log("Saved");
			UxmlReferenceCodeGenerator.GenerateCode(uxml, createDirectory: false);
		}

		/// <summary>
		/// Called when [uxml moved].
		/// </summary>
		/// <param name="oldPath">The old path.</param>
		/// <param name="uxml">The uxml.</param>
		private static void OnUxmlMoved(string oldPath, UxmlAssetDefinition uxml)
		{
			UxmlLogger.Log($"Uxml moved '{oldPath}' to '{uxml.AssetPath}'.");

			// Update reference.
			var folder = Path.GetDirectoryName(uxml.ReferenceClass).ToAssetPath();
			var uxmlName = Path.GetFileNameWithoutExtension(uxml.AssetPath);
			var newReference = GetReferenceClassName(uxmlName, folder);

			UxmlLogger.Log($"Updating config.");
			UxmlAssetConfiguration.Instance.References.Remove(oldPath);
			UxmlAssetConfiguration.Instance.References.Add(uxml.AssetPath, uxml);

			UxmlLogger.Log($"Updating reference: '{uxml.ReferenceClass}' => '{newReference}'");
			AssetDatabase.MoveAsset(uxml.ReferenceClass, newReference);
			uxml.ReferenceClass = newReference;
			UxmlAssetConfiguration.Instance.Save();

			// Update watcher.
			DeleteWatcherEntryIfExists(oldPath);
			AddWatcherEntryIfNotExist(uxml.AssetPath);
		}

		/// <summary>
		/// Called when [uxml deleted].
		/// </summary>
		/// <param name="path">The uxml path.</param>
		private static void OnUxmlDeleted(string path)
		{
			var current = UxmlAssetConfiguration.Instance.References[path];

			UxmlAssetConfiguration.Instance.References.Remove(path);
			if (!string.IsNullOrEmpty(current.ReferenceClass) && File.Exists(current.ReferenceClass))
			{
				UxmlLogger.Log($"Deleting '{current.ReferenceClass}'.");
				AssetDatabase.DeleteAsset(current.ReferenceClass);
			}

			// Update watcher.
			DeleteWatcherEntryIfExists(path);
		}
	}
}
