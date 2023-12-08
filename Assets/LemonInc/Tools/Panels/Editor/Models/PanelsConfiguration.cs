using System;
using LemonInc.Core.Utilities;
using UnityEditor;

namespace LemonInc.Tools.Panels.Models
{
	/// <summary>
	/// Game design state.
	/// </summary>
	[FilePath("Plugins/LemonInc/Resources/Panels/PanelsConfiguration.asset", FilePathAttribute.Location.ProjectFolder)]
	public class PanelsConfiguration : ScriptableSingleton<PanelsConfiguration>
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