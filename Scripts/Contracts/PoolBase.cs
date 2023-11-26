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
	/// <seealso cref="LemonInc.Core.Pooling.Contracts.IPool"/>
	public abstract class PoolBase : MonoBehaviour, IPool
	{
		/// <summary>
		/// Gets the prefab.
		/// </summary>
		public abstract GameObject Prefab { get; protected set; }

		/// <summary>
		/// Gets the initial copies.
		/// </summary>
		public abstract int InitialCopies { get; protected set; }

		/// <summary>
		/// Managed pool.
		/// </summary>
		protected abstract IDictionary<PoolState, IList<IPoolable>> Pool { get; }

		/// <summary>
		/// Called when [validate].
		/// </summary>
		/// <exception cref="PoolException">Prefab should be an {nameof(IPoolable)}.</exception>
		private void OnValidate()
		{
			if (Prefab != null && Prefab.GetComponent<IPoolable>() == null)
			{
				throw new PoolException($"Prefab should be an {nameof(IPoolable)}.");
			}
		}

		/// <summary>
		/// Ensures the initialization.
		/// </summary>
		private void EnsureInitialized()
		{
			if (Pool.Count == 0)
			{
				throw new PoolException("The Pool was not populated.");
			}
		}

		/// <inheritdoc/>
		public void Configure(PoolSettings settings)
		{
			Prefab = settings.Prefab;
			InitialCopies = settings.InitialCount;
		}

		/// <inheritdoc/>
		public void Populate()
		{
			if (Pool.Count > 0 || Prefab == null) return;
			OnValidate();

			Pool.Add(PoolState.FREE, new List<IPoolable>());
			Pool.Add(PoolState.BUSY, new List<IPoolable>());

			for (int i = 0; i < InitialCopies; i++)
			{
				var instance = Instantiate(Prefab, transform);
				var poolable = instance.GetComponent<IPoolable>();

				poolable.State = PoolState.FREE;
				Pool[PoolState.FREE].Add(poolable);
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

			if (!Pool[PoolState.BUSY].Contains(poolable))
				return;

			foreach (var poolEntry in Pool)
			{
				poolEntry.Value.Remove(poolable);
			}

			Pool[PoolState.FREE].Add(poolable);
			poolable.Instance.transform.parent = transform;
			poolable.State = PoolState.FREE;
		}

		/// <inheritdoc/>
		public void ReleaseAll(PoolState ofState = PoolState.BUSY)
		{
			if (ofState == PoolState.FREE)
				throw new PoolException($"Inconsistent ReleaseAll() call. Cannot release '{nameof(PoolState.FREE)}' state.");

			foreach (var poolable in Pool[ofState].ToList())
			{
				poolable.State = PoolState.FREE;
				poolable.Instance.transform.parent = transform;
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
			var instance = Pool[PoolState.FREE].FirstOrDefault() ?? Instantiate(Prefab).GetComponent<IPoolable>();

			Pool[PoolState.FREE].Remove(instance);
			Pool[PoolState.BUSY].Add(instance);
			instance.State = PoolState.BUSY;
			return instance;
		}
	}
}