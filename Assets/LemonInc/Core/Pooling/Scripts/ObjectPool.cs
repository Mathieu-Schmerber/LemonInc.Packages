using System.Collections.Generic;
using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

namespace LemonInc.Core.Pooling
{
	/// <summary>
	/// <see cref="PoolBase"/> implementation.
	/// </summary>
	/// <seealso cref="LemonInc.Core.Pooling.Contracts.PoolBase" />
	public class ObjectPool : PoolBase
	{
		[SerializeField] private GameObject _prefab;
		[SerializeField, Min(0)] private int _initialCopies;

		/// <inheritdoc/>
		protected override GameObject Prefab 
		{ 
			get => _prefab;
			set => _prefab = value;
		}

		/// <inheritdoc/>
		protected override int InitialCopies
		{
			get => _initialCopies;
			set => _initialCopies = value;
		}

		/// <inheritdoc/>
		protected override IDictionary<PoolState, IList<IPoolable>> Pool { get; } = new Dictionary<PoolState, IList<IPoolable>>();
	}
}