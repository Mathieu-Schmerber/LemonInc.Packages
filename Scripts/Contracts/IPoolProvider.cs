using System;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// Provides with <see cref="IPool"/>
	/// </summary>
	/// <typeparam name="T">Stored key type.</typeparam>
	public interface IPoolProvider<in T>
	{
		/// <summary>
		/// Creates a pool.
		/// </summary>
		/// <param name="key">The pool key.</param>
		/// <param name="settings">Pool settings.</param>
		/// <param name="populate">Populates the pool on creation if true.</param>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool Create(T key, PoolSettings settings, bool populate = false);

		/// <summary>
		/// Gets a pool.
		/// </summary>
		/// <param name="key">The pool key.</param>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool Get(T key);

		/// <summary>
		/// Gets or creates a pool.
		/// </summary>
		/// <param name="key">The pool key.</param>
		/// <param name="settings">Pool settings.</param>
		/// <param name="populate">Populates the pool on creation if true.</param>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool GetOrCreate(T key, PoolSettings settings, bool populate = false);
	}
}