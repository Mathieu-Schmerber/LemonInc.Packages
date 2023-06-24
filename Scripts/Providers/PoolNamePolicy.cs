using System;
using System.Linq;

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
	}
}