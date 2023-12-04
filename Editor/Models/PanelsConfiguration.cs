using System;
using LemonInc.Core.Utilities;
using Sirenix.Utilities;
using UnityEditor;

namespace LemonInc.Tools.Panels.Models
{
	/// <summary>
	/// Game design state.
	/// </summary>
	[GlobalConfig("Plugins/LemonInc/Resources/Panels/")]
	public class PanelsConfiguration : GlobalConfig<PanelsConfiguration>
	{
		/// <summary>
		/// The panel dictionary.
		/// </summary>
		[Serializable]
		public class PanelDictionary : SerializedDictionary<string, PanelDefinition> {}

		/// <summary>
		/// The panels.
		/// </summary>
		public PanelDictionary Panels;

		/// <summary>
		/// Called when [configuration automatic created].
		/// </summary>
		protected override void OnConfigAutoCreated()
		{
			Panels = new PanelDictionary();
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