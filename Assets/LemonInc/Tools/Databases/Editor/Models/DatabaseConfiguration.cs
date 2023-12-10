using System.Collections.Generic;
using LemonInc.Editor.Utilities.Configuration;

namespace LemonInc.Tools.Databases.Models
{
	/// <summary>
	/// Database configuration.
	/// </summary>
	[ConfigurationAsset("Plugins/LemonInc/Resources/Databases")]
	public class DatabaseConfiguration : ConfigurationAsset<DatabaseConfiguration>
	{
		/// <summary>
		/// The sections definitions.
		/// </summary>
		public SectionDescriptionDictionary SectionDefinitions;

		/// <summary>
		/// The asset definitions.
		/// </summary>
		public AssetDictionary AssetDefinitions;

		/// <summary>
		/// The database ids.
		/// </summary>
		public List<string> DatabaseIds;

		/// <summary>
		/// The last selected database identifier.
		/// </summary>
		public string LastSelectedDatabaseId;

		/// <summary>
		/// The last selected section identifier.
		/// </summary>
		public string LastSelectedSectionId;

		/// <summary>
		/// The last selected asset identifier.
		/// </summary>
		public string LastSelectedAssetId;

		/// <summary>
		/// The script path.
		/// </summary>
		public string ScriptPath;
		
		/// <summary>
		/// On enable.
		/// </summary>
		private void OnEnable()
		{
			SectionDefinitions ??= new SectionDescriptionDictionary();
			AssetDefinitions ??= new AssetDictionary();
			DatabaseIds ??= new List<string>();
		}
	}
}
