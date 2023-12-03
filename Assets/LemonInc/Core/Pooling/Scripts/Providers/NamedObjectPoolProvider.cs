using System.Collections.Generic;
using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

namespace LemonInc.Core.Pooling.Providers
{
	/// <summary>
	/// Implementation of <see cref="PoolProviderBase{T}"/>.
	/// </summary>
	public class NamedObjectPoolProvider : PoolProviderBase<string>
	{
		/// <summary>
		/// The pools.
		/// </summary>
		private Dictionary<string, IPool> _pools;

		/// <inheritdoc/>
		protected override IDictionary<string, IPool> Pools => _pools ??= FetchPools();

		/// <summary>
		/// Fetches the pools.
		/// </summary>
		/// <returns>The pools.</returns>
		private Dictionary<string, IPool> FetchPools()
		{
			var result = new Dictionary<string, IPool>();

			foreach (var pool in GetComponentsInChildren<ObjectPool>())
			{
				if (PoolNamePolicy<string>.TryGetKey(pool.name, out var key))
				{
					result.TryAdd(key, pool);
				}
			}

			return result;
		}

		/// <inheritdoc/>
		protected override IPool CreatePool(string key)
		{
			var instance = new GameObject(PoolNamePolicy<string>.GetPoolName(key))
			{
				transform = {
					parent = transform
				}
			};
			return instance.AddComponent<ObjectPool>();
		}

		/// <summary>
		/// Awakes this instance.
		/// </summary>
		private void Awake()
		{
			_pools = FetchPools();
		}

#if UNITY_EDITOR

		public IDictionary<string, IPool> GetPools() => FetchPools();

#endif
	}
}