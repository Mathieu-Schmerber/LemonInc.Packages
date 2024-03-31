using System;
using LemonInc.Core.Utilities;
using LemonInc.Core.Utilities.Editor.Configuration;

namespace LemonInc.Tools.Panels.Models
{
	/// <summary>
	/// Game design state.
	/// </summary>
	[ConfigurationAsset("Plugins/LemonInc/Resources/Panels")]
	public class PanelsConfiguration : ConfigurationAsset<PanelsConfiguration>
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
		/// Called when [enable].
		/// </summary>
		private void OnEnable()
		{
			Panels ??= new PanelDictionary();
		}
	}
}