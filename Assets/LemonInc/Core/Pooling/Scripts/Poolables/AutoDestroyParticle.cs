using LemonInc.Core.Pooling.Contracts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LemonInc.Core.Pooling.Poolables
{
	public class AutoDestroyParticle : PoolableBase
	{
		private List<ParticleSystem> _ps;

		private void Awake()
		{
			_ps = transform.GetComponentsInChildren<ParticleSystem>().ToList();
			_ps.Add(GetComponent<ParticleSystem>());
			_ps.RemoveAll(x => x == null);
		}

		protected override void OnInitialize(object data)
		{
			var time = _ps.Max(x => x.main.startLifetime.constantMax) + _ps.Max(x => x.main.startDelay.constantMax);
			Invoke(nameof(Release), time);
		}

		protected override void OnRelease()
		{

		}
	}
}
