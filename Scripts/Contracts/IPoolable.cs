using UnityEngine;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// Describe a Pool entity.
	/// </summary>
	public interface IPoolable
	{
		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		public GameObject Instance { get; }

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		public PoolState State { get; set; }

		/// <summary>
		/// Initializes the poolable.
		/// </summary>
		/// <param name="owner">The owning <see cref="IPool"/>.</param>
		/// <param name="data">Initialization data.</param>
		void Initialize(IPool owner, object data);
		
		/// <summary>
		/// Releases the poolable.
		/// </summary>
		void Release();
	}
}