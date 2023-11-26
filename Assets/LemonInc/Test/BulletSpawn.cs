using System.Collections;
using System.Collections.Generic;
using LemonInc.Core.Pooling.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private PoolBase _pool;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2);
    }

    private void Spawn()
    {
	    _pool.Get(null, transform.position, Quaternion.identity);
    }
}
