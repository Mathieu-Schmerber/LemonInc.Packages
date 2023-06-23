using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

namespace Assets.Testing.Script
{
	public class ScalingCube : PoolableBase
	{
		protected override void OnInitialize(object data)
		{ 
		}

		protected override void OnRelease()
		{
		}

		private void Update()
		{
			transform.localScale = Vector3.one * Mathf.Sin(Time.time);
		}
	}
}
