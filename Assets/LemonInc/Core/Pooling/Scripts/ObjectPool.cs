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
		public bool PopulateOnAwake = true;

		/// <inheritdoc/>
		public override GameObject Prefab 
		{ 
			get => _prefab;
			protected set => _prefab = value;
		}

		/// <inheritdoc/>
		public override int InitialCopies
		{
			get => _initialCopies;
			protected set => _initialCopies = value;
		}

		/// <inheritdoc/>
		protected override IDictionary<PoolState, IList<IPoolable>> Pool { get; } = new Dictionary<PoolState, IList<IPoolable>>();

		private void Awake()
		{
			if (PopulateOnAwake)
			{
				Populate();
			}
		}
	}
}