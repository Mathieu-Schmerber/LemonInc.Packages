namespace LemonInc.Tools.Databases.Interfaces
{
	/// <summary>
	/// Naming policy.
	/// </summary>
	public interface INamingPolicy
	{
		/// <summary>
		/// Validates the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="error">The error.</param>
		/// <returns>True if the name fits the policy.</returns>
		bool Validate(string name, out string error);
	}
}