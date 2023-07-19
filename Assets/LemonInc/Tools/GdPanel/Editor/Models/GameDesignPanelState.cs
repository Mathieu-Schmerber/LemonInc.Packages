using Sirenix.Utilities;
using UnityEditor;

namespace LemonInc.Tools.GdPanel.Models
{
	/// <summary>
	/// Game design state.
	/// </summary>
	/// <seealso cref="UnityEditor.ScriptableSingleton&lt;LemonInc.Tools.GdPanel.GameDesignPanelState&gt;" />
	[GlobalConfig("Plugins/LemonInc/Resources/GdPanel")]
	public class GameDesignPanelState : GlobalConfig<GameDesignPanelState>
	{
		/// <summary>
		/// Gets or sets the target folder.
		/// </summary>
		/// <value>
		/// The target folder.
		/// </value>
		public string TargetFolder;

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