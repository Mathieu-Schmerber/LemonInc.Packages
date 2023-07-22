using System;
using LemonInc.Core.Utilities;
using Sirenix.Utilities;
using UnityEditor;

namespace LemonInc.Editor.Uxml
{
	/// <summary>
	/// Uxml Asset Configuration.
	/// </summary>
	[GlobalConfig("Plugins/LemonInc/Resources/Uxml")]
	public class UxmlAssetConfiguration : GlobalConfig<UxmlAssetConfiguration>
	{
		/// <summary>
		/// Key is asset path.
		/// </summary>
		[Serializable]
		public class UxmlReferenceDictionary : SerializedDictionary<string, UxmlAssetDefinition> {}

		/// <summary>
		/// The references.
		/// </summary>
		public UxmlReferenceDictionary References;

		/// <summary>
		/// The log trace.
		/// </summary>
		public bool DoLogTrace;

		/// <summary>
		/// Called when [configuration automatic created].
		/// </summary>
		protected override void OnConfigAutoCreated()
		{
			References = new UxmlReferenceDictionary();
			DoLogTrace = false;
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public void Save()
		{
			EditorUtility.SetDirty(this);
			AssetDatabase.SaveAssetIfDirty(this);
		}
	}
}