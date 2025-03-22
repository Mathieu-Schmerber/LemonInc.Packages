using LemonInc.Core.Pooling.Providers;
using LemonInc.Core.Utilities;
using LemonInc.Core.Utilities.Extensions;
using UnityEngine;

namespace LemonInc.Test.PoolingDemo.Scripts
{
    public class SphereSpawner : MonoBehaviour
    {
        [SerializeField] private NamedObjectPoolProvider _pool;
        [SerializeField] private readonly Timer _timer = new(autoReset: true);
        
        private Bounds _bounds;

        private void Awake()
        {
            _bounds = GetComponent<Collider>().bounds;
        }

        private void Start()
        {
            _timer.SetOnTickCallback(SpawnSphere);
            _timer.Start();
        }

        private void SpawnSphere()
        {
            var pos = _bounds.GetRandomPoint();
            //_pool.Get();
        }
    }
}