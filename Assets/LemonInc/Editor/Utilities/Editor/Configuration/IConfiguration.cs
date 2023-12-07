namespace LemonInc.Editor.Utilities.Configuration
{
	/// <summary>
	/// Describes a configuration.
	/// </summary>
	public interface IConfiguration
	{
		/// <summary>
		/// Called when [created].
		/// </summary>
		void OnCreated();

		/// <summary>
		/// Called when [loaded].
		/// This will also be called after a creation.
		/// </summary>
		void OnLoaded();
	}
}