using System.Collections;
using LemonInc.Core.Pooling;
using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

namespace Assets.Testing.Script
{
	public class CubeSpawn : MonoBehaviour
	{
		private IPoolProvider _poolProvider;
		[SerializeField] private GameObject _prefab;

		private void Awake()
		{
			_poolProvider = FindObjectOfType<ObjectPoolProvider>();
		}

		private void Start()
		{
			var rotPool = _poolProvider.GetOrCreatePoolOf<RotatingCube>(new PoolSettings()
			{
				Prefab = _prefab
			}, true);
			
			rotPool.Get(null, poolable => Debug.Log("Spawned new."));
			Invoke(nameof(ReleasePool), 3f);
		}

		private void ReleasePool()
		{
			var rotPool = _poolProvider.GetPoolOf<RotatingCube>();

			rotPool.ReleaseAll();
		}
	}
}
