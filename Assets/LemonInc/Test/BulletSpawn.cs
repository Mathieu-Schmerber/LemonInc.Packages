using LemonInc.Core.Pooling;
using LemonInc.Core.Pooling.Contracts;
using LemonInc.Core.Pooling.Providers;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
	[SerializeField] private NamedObjectPoolProvider _poolProvider;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2);
    }

    private void Spawn()
    {
	    _poolProvider.Get(Pool.Bullet.ToString()).Get(null, transform.position, Quaternion.identity);
	}
}
