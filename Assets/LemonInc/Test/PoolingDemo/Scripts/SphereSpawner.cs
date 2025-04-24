using LemonInc.Core.Pooling;
using LemonInc.Core.Pooling.Contracts;
using LemonInc.Core.Pooling.Providers;
using LemonInc.Core.Utilities;
using LemonInc.Core.Utilities.Extensions;
using UnityEngine;

namespace LemonInc.Test.PoolingDemo.Scripts
{
    public class SphereSpawner : MonoBehaviour
    {
        [SerializeField] private NamedObjectPoolProvider _poolProvider;
        [SerializeField] private readonly Timer _timer = new(autoReset: true);
        
        private Bounds _bounds;
        private IPool _pool;

        private void Awake()
        {
            _bounds = GetComponent<Collider>().bounds;
            _pool = _poolProvider.Get(Pool.Sphere.ToString());
        }

        private void Start()
        {
            _timer.AddOnTickListener(SpawnSphere);
            _timer.Start();
        }

        private void SpawnSphere()
        {
            var pos = _bounds.GetRandomPoint();
            _pool.Get(new SphereInstance.Settings
            {
                Color = new Color(Random.value, Random.value, Random.value),
                Lifetime = (Random.value + 1) * 2f
            }, pos, Quaternion.identity);
        }
    }
}