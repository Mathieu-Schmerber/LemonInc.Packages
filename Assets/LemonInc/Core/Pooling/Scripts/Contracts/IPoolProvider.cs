using System;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// Provides with <see cref="IPool"/>
	/// </summary>
	public interface IPoolProvider
	{
		/// <summary>
		/// Creates a pool.
		/// </summary>
		/// <typeparam name="TPool">The type of the pool.</typeparam>
		/// <returns>The <see cref="IPool"/>.</returns>
		TPool CreatePoolOfType<TPool>()
			where TPool : IPool;

		/// <summary>
		/// Gets the pool of type.
		/// </summary>
		/// <typeparam name="TPool">The type of the pool.</typeparam>
		/// <returns>The <see cref="IPool"/>.</returns>
		TPool GetOfType<TPool>()
			where TPool : IPool;

		/// <summary>
		/// Creates a pool for the specified poolable type.
		/// </summary>
		/// <typeparam name="TPoolable">The type of the poolable.</typeparam>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool CreatePoolForType<TPoolable>()
			where TPoolable : IPoolable;

		/// <summary>
		/// Gets the pool for the specified poolable type.
		/// </summary>
		/// <typeparam name="TPoolable">The type of the poolable.</typeparam>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool GetPoolForType<TPoolable>()
			where TPoolable : IPoolable;

		/// <summary>
		/// Creates a pool.
		/// </summary>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool CreatePoolOfType(Type type);

		/// <summary>
		/// Gets the pool of type.
		/// </summary>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool GetOfType(Type type);

		/// <summary>
		/// Creates a pool for the specified poolable type.
		/// </summary>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool CreatePoolForType(Type type);

		/// <summary>
		/// Gets the pool for the specified poolable type.
		/// </summary>
		/// <returns>The <see cref="IPool"/>.</returns>
		IPool GetPoolForType(Type type);
	}
}