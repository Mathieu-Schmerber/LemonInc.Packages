using UnityEngine;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
    /// Describes a Pool.
    /// </summary>
    public interface IPool
	{
		/// <summary>
		/// Configures the pool.
		/// </summary>
		/// <param name="settings">The settings.</param>
		void Configure(PoolSettings settings);

		/// <summary>
		/// Populates this instance.
		/// </summary>
		void Populate();

		/// <summary>
		/// Gets an entity from the pool.
		/// </summary>
		/// <param name="data">Arbitrary init data.</param>
		/// <param name="postInitAction">The post initialize action.</param>
		/// <returns>The <see cref="IPoolable"/>.</returns>
		IPoolable Get(object data, System.Action<IPoolable> postInitAction = null);

		/// <summary>
		/// Gets an entity from the pool.
		/// </summary>
		/// <param name="data">Arbitrary init data.</param>
		/// <param name="position">The position.</param>
		/// <param name="rotation">The rotation.</param>
		/// <param name="postInitAction">The post initialize action.</param>
		/// <returns>The <see cref="IPoolable"/>.</returns>
		IPoolable Get(object data, Vector3 position, Quaternion rotation, System.Action<IPoolable> postInitAction = null);

		/// <summary>
		/// Releases the specified poolable.
		/// </summary>
		/// <param name="poolable">The poolable.</param>
		void Release(IPoolable poolable);

		/// <summary>
		/// Releases all.
		/// </summary>
		/// <param name="ofState">Exclusive state to release.</param>
		void ReleaseAll(PoolState ofState = PoolState.BUSY);
    }
}
