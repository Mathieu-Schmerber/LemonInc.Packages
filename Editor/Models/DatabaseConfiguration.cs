using System.Collections.Generic;
using LemonInc.Editor.Utilities.Configuration;
using Sirenix.OdinInspector;

namespace LemonInc.Tools.Databases.Models
{
	/// <summary>
	/// Database configuration.
	/// </summary>
	public class DatabaseConfiguration : ConfigurationAsset
	{
		/// <summary>
		/// The sections definitions.
		/// </summary>
		[ReadOnly] public SectionDescriptionDictionary SectionDefinitions;

		/// <summary>
		/// The asset definitions.
		/// </summary>
		[ReadOnly] public AssetDictionary AssetDefinitions;

		/// <summary>
		/// The database ids.
		/// </summary>
		[ReadOnly] public List<string> DatabaseIds;

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

		/// <inheritdoc />
		public override void OnCreated()
		{
			SectionDefinitions = new SectionDescriptionDictionary();
			AssetDefinitions = new AssetDictionary();
			DatabaseIds = new List<string>();
		}
	}
}
