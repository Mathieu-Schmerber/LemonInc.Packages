using LemonInc.Editor.Utilities.Configuration;

namespace LemonInc.Tools.Databases.Editor.Models
{
	/// <summary>
	/// Database configuration.
	/// </summary>
	[ConfigurationAsset("Plugins/LemonInc/Resources/Databases")]
	public class DatabaseConfiguration : ConfigurationAsset<DatabaseConfiguration>
	{
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
	}
}
