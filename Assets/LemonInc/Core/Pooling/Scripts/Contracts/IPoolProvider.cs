using System;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// Provides with <see cref="IPool"/>
	/// </summary>
	public interface IPoolProvider
	{
		/// <summary>
		/// Creates a pool to manage the specified type.
		/// </summary>
		/// <param name="settings">Pool settings.</param>
		/// <param name="populate">Populates the pool on creation if true.</param>
		/// <typeparam name="TPoolable">The type of the poolable.</typeparam>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool CreatePoolOf<TPoolable>(PoolSettings settings, bool populate = false)
			where TPoolable : IPoolable;

		/// <summary>
		/// Creates a pool to manage the specified type.
		/// </summary>
		/// <param name="type">The type of the poolable.</param>
		/// <param name="settings">Pool settings.</param>
		/// <param name="populate">Populates the pool on creation if true.</param>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool CreatePoolOf( Type type, PoolSettings settings, bool populate = false);

		/// <summary>
		/// Gets the pool for the specified poolable type.
		/// </summary>
		/// <typeparam name="TPoolable">The type of the poolable.</typeparam>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool GetPoolOf<TPoolable>()
			where TPoolable : IPoolable;

		/// <summary>
		/// Gets the pool for the specified poolable type.
		/// </summary>
		/// <param name="type">The type of the poolable.</param>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool GetPoolOf(Type type);

		/// <summary>
		/// Gets or creates a pool of the specified type.
		/// </summary>
		/// <param name="settings">Pool settings.</param>
		/// <param name="populate">Populates the pool on creation if true.</param>
		/// <typeparam name="TPoolable">The type of the poolable.</typeparam>
		/// <returns></returns>
		IPool GetOrCreatePoolOf<TPoolable>(PoolSettings settings, bool populate = false) where TPoolable : IPoolable;

		/// <summary>
		/// Gets or creates a pool of the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="settings">Pool settings.</param>
		/// <param name="populate">Populates the pool on creation if true.</param>
		/// <returns></returns>
		IPool GetOrCreatePoolOf(Type type, PoolSettings settings, bool populate = false);
	}
}