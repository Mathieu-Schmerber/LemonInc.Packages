using System;
using LemonInc.Core.Utilities;
using LemonInc.Editor.Utilities.Configuration;
using Sirenix.Utilities;
using UnityEditor;

namespace LemonInc.Editor.Uxml
{
	/// <summary>
	/// Uxml Asset Configuration.
	/// </summary>
	[FilePath("Plugins/LemonInc/Resources/UXML/UxmlAssetConfiguration.asset", FilePathAttribute.Location.ProjectFolder)]
	public class UxmlAssetConfiguration : ScriptableSingleton<UxmlAssetConfiguration>
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
		/// Called when [enable].
		/// </summary>
		private void OnEnable()
		{
			References ??= new UxmlReferenceDictionary();
		}
	}
}