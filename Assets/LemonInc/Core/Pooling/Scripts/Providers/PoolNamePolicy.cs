namespace LemonInc.Core.Pooling.Providers
{
	/// <summary>
	/// Pool name policy.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public static class PoolNamePolicy<T>
	{
		/// <summary>
		/// Gets the name of the pool.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public static string GetPoolName(T key) => $"Pool - '{key}'";

		/// <summary>
		/// Retrieves the key as string.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public static string RetrieveKeyAsString(string name) => name.Replace("Pool - ", string.Empty).Replace("'", string.Empty);

		/// <summary>
		/// Tries getting the key.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The name.</param>
		/// <param name="key">The key.</param>
		/// <returns><c>true</c> if the key could be parsed.</returns>
		public static bool TryGetKey(string name, out string key)
		{
			key = default;

			if (!name.StartsWith("Pool - '") || !name.EndsWith("'")) 
				return false;

			key = name.Substring(8, name.Length - 9);
			return true;

		}
	}
}