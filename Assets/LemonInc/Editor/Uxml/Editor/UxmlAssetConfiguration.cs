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
	public class UxmlAssetConfiguration : ConfigurationAsset
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

		public override void OnCreated()
		{
			References = new UxmlReferenceDictionary();
			DoLogTrace = false;
		}
	}
}