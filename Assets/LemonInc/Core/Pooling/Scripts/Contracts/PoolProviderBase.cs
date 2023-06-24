using System;
using System.Collections.Generic;
using LemonInc.Core.Pooling.Exceptions;
using UnityEngine;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// <see cref="IPoolProvider{T}"/> base implementation.
	/// </summary>
	/// <seealso cref="LemonInc.Core.Pooling.Contracts.IPoolProvider{T}" />
	/// <keyparam name="TKey">Storing key key.</keyparam>
	public abstract class PoolProviderBase<TKey> : MonoBehaviour, IPoolProvider<TKey>
	{
		/// <summary>
		/// The pools.
		/// </summary>
		protected abstract IDictionary<TKey, IPool> Pools { get; }

		/// <summary>
		/// Creates the pool.
		/// </summary>
		/// <param name="key">The pool key.</param>
		/// <returns>The <see cref="IPool"/>.</returns>
		protected abstract IPool CreatePool(TKey key);

		/// <summary>
		/// Ensures the initialized.
		/// </summary>
		/// <exception cref="LemonInc.Core.Pooling.Exceptions.PoolException"></exception>
		private void EnsureInitialized()
		{
			if (Pools == null)
				throw new PoolException($"{nameof(PoolProviderBase<TKey>.Pools)} was not initialized.");
		}
		
		/// <inheritdoc/>
		public virtual IPool Create(TKey key, PoolSettings settings, bool populate = false)
		{
			EnsureInitialized();

			if (Pools.ContainsKey(key))
			{
				throw new PoolException($"A pool of key {key} has already been registered.");
			}

			var pool = CreatePool(key);
			pool.Configure(settings);
			if (populate)
			{
				pool.Populate();
			}

			Pools.Add(key, pool);
			return pool;
		}

		/// <inheritdoc/>
		public virtual IPool Get(TKey key)
		{
			EnsureInitialized();

			if (!Pools.ContainsKey(key))
			{
				throw new PoolException($"No pool of key {key} has been registered.");
			}

			return Pools[key];
		}

		/// <inheritdoc/>
		public virtual IPool GetOrCreate(TKey key, PoolSettings settings, bool populate = false)
		{
			EnsureInitialized();

			return !Pools.ContainsKey(key) ? Create(key, settings, populate) : Get(key);
		}
	}
}