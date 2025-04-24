using System;
using LemonInc.Core.Pooling;
using LemonInc.Core.Pooling.Contracts;
using UnityEngine;

namespace LemonInc.Test.PoolingDemo.Scripts
{
    public class SphereInstance : PoolableBase
    {
        private static readonly int ColorProp = Shader.PropertyToID("_Color");
        private MeshRenderer _renderer;
        private float _timer;
        private float _lifetime;

        public struct Settings
        {
            public float Lifetime;
            public Color Color;
        }

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            transform.localScale += Vector3.one * (.1f * Time.deltaTime);
            _timer += Time.deltaTime;
            if (State == PoolState.BUSY && _timer > _lifetime)
                Release();
        }

        protected override void OnInitialize(object data)
        {
            var settings = (Settings)data;
        
            _renderer.material.SetColor(ColorProp, settings.Color);
            _timer = 0f;
            _lifetime = settings.Lifetime;
        }

        protected override void OnRelease() { }
    }
}
