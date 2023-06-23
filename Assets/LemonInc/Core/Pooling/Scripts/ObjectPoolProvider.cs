using System;
using System.Collections.Generic;
using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

namespace LemonInc.Core.Pooling
{
	/// <summary>
	/// Implementation of <see cref="PoolProviderBase"/>.
	/// </summary>
	/// <seealso cref="LemonInc.Core.Pooling.Contracts.PoolProviderBase" />
	public class ObjectPoolProvider : PoolProviderBase
	{
		/// <inheritdoc/>
		protected override IDictionary<Type, IPool> Pools { get; } = new Dictionary<Type, IPool>();

		/// <inheritdoc/>
		protected override IPool CreatePool()
		{
			var instance = Instantiate(new GameObject(), transform);
			return instance.AddComponent<ObjectPool>();
		}
	}
}