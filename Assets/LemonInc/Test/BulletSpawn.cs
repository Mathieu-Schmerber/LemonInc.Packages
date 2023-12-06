using LemonInc.Core.Pooling;
using LemonInc.Core.Pooling.Providers;
using LemonInc.Tools.Databases;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
	[SerializeField] private NamedObjectPoolProvider _poolProvider;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2);
        Instantiate(Databases.Test.Okk.Err.Bullet);
    }

    private void Spawn()
    {
	    _poolProvider.Get(Pool.Bullet.ToString()).Get(null, transform.position, Quaternion.identity);
	}
}
