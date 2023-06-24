﻿using System.Collections.Generic;
using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

namespace LemonInc.Core.Pooling.Providers
{
	/// <summary>
	/// Implementation of <see cref="PoolProviderBase{T}"/>.
	/// </summary>
	public class NamedObjectPoolProvider : PoolProviderBase<string>
	{
		/// <inheritdoc/>
		protected override IDictionary<string, IPool> Pools { get; } = new Dictionary<string, IPool>();

		/// <inheritdoc/>
		protected override IPool CreatePool(string key)
		{
			var instance = new GameObject(PoolNamePolicy<string>.GetPoolName(key))
			{
				transform = {
					parent = transform
				}
			};
			return instance.AddComponent<ObjectPool>();
		}
	}
}