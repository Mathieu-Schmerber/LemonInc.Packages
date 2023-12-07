using System;
using LemonInc.Core.Utilities;
using LemonInc.Editor.Utilities.Configuration;

namespace LemonInc.Tools.Panels.Models
{
	/// <summary>
	/// Game design state.
	/// </summary>
	public class PanelsConfiguration : ConfigurationAsset
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
		public override void OnCreated()
		{
			Panels = new PanelDictionary();
		}
	}
}