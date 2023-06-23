using System;
using System.Collections.Generic;
using LemonInc.Core.Pooling.Exceptions;
using UnityEngine;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// <see cref="IPoolProvider"/> base implementation.
	/// </summary>
	/// <seealso cref="LemonInc.Core.Pooling.Contracts.IPoolProvider" />
	public abstract class PoolProviderBase : MonoBehaviour, IPoolProvider
	{
		/// <summary>
		/// The pools.
		/// </summary>
		protected abstract IDictionary<Type, IPool> Pools { get; }

		/// <summary>
		/// Creates the pool.
		/// </summary>
		/// <returns>The <see cref="IPool"/>.</returns>
		protected abstract IPool CreatePool();

		/// <summary>
		/// Ensures the initialized.
		/// </summary>
		/// <exception cref="LemonInc.Core.Pooling.Exceptions.PoolException"></exception>
		private void EnsureInitialized()
		{
			if (Pools == null)
				throw new PoolException($"{nameof(PoolProviderBase.Pools)} was not initialized.");
		}

		/// <inheritdoc/>
		public IPool CreatePoolOf<TPoolable>(PoolSettings settings, bool populate = false) where TPoolable : IPoolable => CreatePoolOf(typeof(TPoolable), settings, populate);

		/// <inheritdoc/>
		public IPool GetPoolOf<TPoolable>() where TPoolable : IPoolable => GetPoolOf(typeof(TPoolable));

		/// <inheritdoc/>
		public IPool GetOrCreatePoolOf<TPoolable>(PoolSettings settings, bool populate = false) where TPoolable : IPoolable => GetOrCreatePoolOf(typeof(TPoolable), settings, populate);

		/// <inheritdoc/>
		public virtual IPool CreatePoolOf(Type type, PoolSettings settings, bool populate = false)
		{
			EnsureInitialized();

			if (Pools.ContainsKey(type))
			{
				throw new PoolException($"A pool of type {type.Name} has already been registered.");
			}

			var pool = CreatePool();
			pool.Configure(settings);
			if (populate)
			{
				pool.Populate();
			}

			Pools.Add(type, pool);
			return pool;
		}

		/// <inheritdoc/>
		public virtual IPool GetPoolOf(Type type)
		{
			EnsureInitialized();

			if (!Pools.ContainsKey(type))
			{
				throw new PoolException($"No pool of type {type.Name} has been registered.");
			}

			return Pools[type];
		}

		/// <inheritdoc/>
		public virtual IPool GetOrCreatePoolOf(Type type, PoolSettings settings, bool populate = false)
		{
			EnsureInitialized();

			return !Pools.ContainsKey(type) ? CreatePoolOf(type, settings, populate) : GetPoolOf(type);
		}
	}
}