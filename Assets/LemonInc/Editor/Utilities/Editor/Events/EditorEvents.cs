using System;
using System.Linq;
using UnityEditor;

namespace LemonInc.Editor.Utilities.Events
{
	/// <summary>
	/// Handles editor events.
	/// </summary>
	public static class EditorEvents
	{
		/// <summary>
		/// Handles asset events.
		/// </summary>
		public class Asset : AssetPostprocessor
		{
			/// <summary>
			/// Occurs after an asset was imported.
			/// </summary>
			public static event OnAssetEvent OnAssetImported;

			/// <summary>
			/// Occurs after an asset was deleted.
			/// </summary>
			public static event OnAssetEvent OnAssetDeleted;

			/// <summary>
			/// Occurs after an asset was moved.
			/// </summary>
			public static event OnAssetMovedEvent OnAssetMoved;

			/// <summary>
			/// Occurs when [on domain reloaded].
			/// </summary>
			public static event Action OnDomainReloaded;

			/// <summary>
			/// On asset event.
			/// </summary>
			/// <param name="assetPath">The asset path, starts at "Assets/".</param>
			public delegate void OnAssetEvent(string assetPath);

			/// <summary>
			/// On asset moved.
			/// </summary>
			/// <param name="oldAssetPath">The old asset path, starts at "Assets/".</param>
			/// <param name="newAssetPath">The new asset path, starts at "Assets/".</param>
			public delegate void OnAssetMovedEvent(string oldAssetPath, string newAssetPath);

			/// <summary>
			/// Called when [postprocess all assets] by Unity.
			/// </summary>
			/// <param name="importedAssets">The imported assets.</param>
			/// <param name="deletedAssets">The deleted assets.</param>
			/// <param name="movedAssets">The moved assets.</param>
			/// <param name="movedFromAssetPaths">The moved from asset paths.</param>
			/// <param name="didDomainReload">if set to <c>true</c> [did domain reload].</param>
			private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload)
			{
				foreach (var str in importedAssets)
				{
					if (!movedAssets.Contains(str))
						OnAssetImported?.Invoke(str);
				}

				foreach (var str in deletedAssets)
				{
					OnAssetDeleted?.Invoke(str);
				}

				for (var i = 0; i < movedAssets.Length; i++)
				{
					OnAssetMoved?.Invoke(movedFromAssetPaths[i], movedAssets[i]);
				}

				if (didDomainReload)
				{
					OnDomainReloaded?.Invoke();
				}
			}
		}
	}
}