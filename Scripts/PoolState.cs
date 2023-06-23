namespace LemonInc.Core.Pooling
{
	/// <summary>
	/// Defines a pool state.
	/// </summary>
	public enum PoolState
	{
		/// <summary>
		/// The free state, entity is in the pool.
		/// </summary>
		FREE,

		/// <summary>
		/// The busy state, entity is active out of the pool.
		/// </summary>
		BUSY
	}
}