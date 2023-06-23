using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Pooling.Exceptions;
using UnityEngine;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// MonoBehaviour implementation of <see cref="IPool"/>.
	/// </summary>
	/// <seealso cref="LemonInc.Core.Pooling.Contracts.IPool" />
	public abstract class PoolBase : MonoBehaviour, IPool
	{
		/// <summary>
		/// The prefab.
		/// </summary>
		[SerializeField] protected GameObject _prefab;

		/// <summary>
		/// The initial copies.
		/// </summary>
		[SerializeField, Min(0)] protected int _initialCopies;

		/// <summary>
		/// Managed pool.
		/// </summary>
		private IDictionary<PoolState, IList<IPoolable>> Pool { get; set; }

		/// <summary>
		/// Called when [validate].
		/// </summary>
		/// <exception cref="LemonInc.Core.Pooling.Exceptions.PoolException">Prefab should be an {nameof(IPoolable)}.</exception>
		private void OnValidate()
		{
			if (_prefab != null && _prefab.GetComponent<IPoolable>() == null)
			{
				throw new PoolException($"Prefab should be an {nameof(IPoolable)}.");
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
		public void Populate()
		{
			if (_prefab == null) throw new PoolException("Prefab is required.");
			OnValidate();

			Pool = new Dictionary<PoolState, IList<IPoolable>>()
			{
				{ PoolState.BUSY, new List<IPoolable>() },
				{ PoolState.FREE, new List<IPoolable>() }
			};

			for (int i = 0; i < _initialCopies; i++)
			{
				var instance = Instantiate(_prefab);
				Pool[PoolState.FREE].Add(instance.GetComponent<IPoolable>());
			}
		}

		/// <inheritdoc/>
		public IPoolable Get(object data, Action<IPoolable> postInitAction = null)
		{
			EnsureInitialized();

			var poolable = RetrieveFromPool();
			poolable.Initialize(this, data);
			postInitAction?.Invoke(poolable);
			return poolable;
		}

		/// <inheritdoc/>
		public IPoolable Get(object data, Vector3 position, Quaternion rotation, Action<IPoolable> postInitAction = null)
		{
			EnsureInitialized();

			var poolable = RetrieveFromPool();

			poolable.Instance.transform.position = position;
			poolable.Instance.transform.rotation = rotation;

			poolable.Initialize(this, data);
			postInitAction?.Invoke(poolable);
			return poolable;
		}
		
		/// <inheritdoc/>
		public void Release(IPoolable poolable)
		{
			EnsureInitialized();

			if (!Pool[PoolState.FREE].Contains(poolable))
				return;

			foreach (var poolEntry in Pool)
			{
				poolEntry.Value.Remove(poolable);
			}

			Pool[PoolState.FREE].Add(poolable);
			poolable.State = PoolState.FREE;
		}

		/// <inheritdoc/>
		public void ReleaseAll(PoolState ofState = PoolState.BUSY)
		{
			if (ofState == PoolState.FREE)
				throw new PoolException($"Inconsistent ReleaseAll() call. Cannot release '{nameof(PoolState.FREE)}' state.");

			foreach (var poolable in Pool[ofState])
			{
				poolable.State = PoolState.FREE;
				Pool[ofState].Remove(poolable);
				Pool[PoolState.FREE].Add(poolable);
			}
		}

		/// <summary>
		/// Retrieves from pool.
		/// </summary>
		/// <returns>The <see cref="IPoolable"/>.</returns>
		private IPoolable RetrieveFromPool()
		{
			var instance = Pool[PoolState.FREE].FirstOrDefault() ?? Instantiate(_prefab).GetComponent<IPoolable>();

			Pool[PoolState.FREE].Remove(instance);
			Pool[PoolState.BUSY].Add(instance);
			instance.State = PoolState.BUSY;
			return instance;
		}
	}
}