using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

namespace Assets.Testing.Script
{
	public class RotatingCube : PoolableBase
	{
		protected override void OnInitialize(object data)
		{ 
		}

		protected override void OnRelease()
		{
		}

		private void Update()
		{
			transform.Rotate(Vector3.up, 30 * Time.deltaTime);
		}
	}
}
