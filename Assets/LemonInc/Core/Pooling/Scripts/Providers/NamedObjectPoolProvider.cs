using System.Collections.Generic;
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
			var instance = Instantiate(new GameObject($"Pool - '{key}'"), transform);
			return instance.AddComponent<ObjectPool>();
		}
	}
}