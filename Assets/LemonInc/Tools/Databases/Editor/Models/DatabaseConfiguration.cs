using Sirenix.OdinInspector;
using Sirenix.Utilities;

namespace LemonInc.Tools.Databases.Models
{
	/// <summary>
	/// Database configuration.
	/// </summary>
	[GlobalConfig("Plugins/LemonInc/Resources/Databases")]
	public class DatabaseConfiguration : GlobalConfig<DatabaseConfiguration>
	{
		/// <summary>
		/// The databases.
		/// </summary>
		[ReadOnly] public SectionDictionary Databases;

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
		/// Called when [configuration automatic created].
		/// </summary>
		protected override void OnConfigAutoCreated()
		{
			base.OnConfigAutoCreated();
			Databases = new SectionDictionary();
		}
	}
}
