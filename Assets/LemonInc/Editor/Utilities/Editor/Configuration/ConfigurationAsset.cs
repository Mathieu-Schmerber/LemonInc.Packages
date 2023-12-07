using UnityEngine;

namespace LemonInc.Editor.Utilities.Configuration
{
	/// <summary>
	/// Describes a configuration asset.
	/// </summary>
	/// <seealso cref="UnityEngine.ScriptableObject" />
	/// <seealso cref="LemonInc.Editor.Utilities.Configuration.IConfiguration" />
	public class ConfigurationAsset : ScriptableObject, IConfiguration
	{
		/// <inheritdoc/>
		public virtual void OnCreated() { }

		/// <inheritdoc/>
		public virtual void OnLoaded() { }
	}
}