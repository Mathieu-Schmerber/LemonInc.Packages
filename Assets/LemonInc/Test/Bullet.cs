using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

public class Bullet : PoolableBase
{
	[SerializeField] private Vector3 _velocity;

	private void OnTriggerEnter(Collider other)
	{
		Release();
	}

	protected override void OnInitialize(object data)
	{
		GetComponent<Rigidbody>().velocity = _velocity;
	}

	protected override void OnRelease()
	{

	}
}