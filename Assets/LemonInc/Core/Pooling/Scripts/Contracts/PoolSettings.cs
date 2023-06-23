using UnityEngine;

namespace LemonInc.Core.Pooling.Contracts
{
	/// <summary>
	/// Pool settings.
	/// </summary>
	public class PoolSettings
	{
		/// <summary>
		/// Gets or sets the prefab.
		/// </summary>
		public GameObject Prefab { get; set; }

		/// <summary>
		/// Gets or sets the initial count.
		/// </summary>
		public int InitialCount { get; set; }
	}
}