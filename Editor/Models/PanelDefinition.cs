using System;
using System.Collections.Generic;

namespace LemonInc.Tools.Panels.Models
{
	/// <summary>
	/// Panel definition.
	/// </summary>
	[Serializable]
	public class PanelDefinition
	{
		/// <summary>
		/// The opened instances
		/// </summary>
		public List<string> OpenedInstances;

		/// <summary>
		/// Gets or sets the target folder.
		/// </summary>
		/// <value>
		/// The target folder.
		/// </value>
		public string TargetFolder;
	}
}