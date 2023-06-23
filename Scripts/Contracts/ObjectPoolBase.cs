using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Pooling.Exceptions;
using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// MonoBehaviour implementation of <see cref="IPool"/>.
	/// </summary>
	/// <seealso cref="LemonInc.Core.Pooling.Contracts.IPool" />
	public class ObjectPoolBase : MonoBehaviour, IPool
	{
		[SerializeField] private GameObject _prefab;
		[SerializeField] private int _initialCopies;

		/// <summary>
		/// Managed pool.
		/// </summary>
		private IDictionary<PoolState, IList<GameObject>> Pool { get; set; }

		private void OnValidate()
		{
			if (_prefab != null && _prefab.GetComponent<IPoolable>() == null)
			{
				throw new PoolException($"Prefab should be an {nameof(IPoolable)}.");
			}
		}

		/// <inheritdoc/>
		public void Populate()
		{
			Pool = new Dictionary<PoolState, IList<GameObject>>()
			{
				{ PoolState.BUSY, new List<T>() },
				{ PoolState.FREE, new List<T>() }
			};

			for (int i = 0; i < _initialCopies; i++)
			{
				var instance = Instantiate(_prefab);
				Pool[PoolState.FREE].Add(instance);
			}
		}

		/// <summary>
		/// Ensures the initialization.
		/// </summary>
		private void EnsureInitialized()
		{
			if (Pool == null)
			{
				throw new PoolException("The Pool was not populated.");
			}
		}

		/// <inheritdoc/>
		public TPoolable Get<TPoolable>(object data) where TPoolable : IPoolable
		{
			EnsureInitialized();

			var entity = Pool[PoolState.FREE].FirstOrDefault();
			if (entity == null)
			{
				entity = Instantiate(_prefab);
				Pool[PoolState.FREE].Add(entity);
			}

			entity.GetComponent<IPoolable>().Initialize(data);
			if (entity is TPoolable result)
				return result;

			throw new PoolException($"Inconsistent Get() call. The return value should be of type {typeof(TPoolable)} but was of type '{typeof(T)}'.");
		}

		/// <inheritdoc/>
		public void Release(IPoolable poolable)
		{
			EnsureInitialized();

			if (!Pool[PoolState.FREE].Contains(_prefab))
				return;

			foreach (var poolEntry in Pool)
			{
				poolEntry.Value.Remove(entity);
			}

			Pool[PoolState.FREE].Add(entity);
		}

		/// <inheritdoc/>
		public void ReleaseAll(PoolState ofState = PoolState.BUSY)
		{
			if (ofState == PoolState.FREE)
				throw new PoolException($"Inconsistent ReleaseAll() call. Cannot release '{nameof(PoolState.FREE)}' state.");

			foreach (var poolable in Pool[ofState])
			{
				Pool[ofState].Remove(poolable);
				Pool[PoolState.FREE].Add(poolable);
			}
		}
	}
}