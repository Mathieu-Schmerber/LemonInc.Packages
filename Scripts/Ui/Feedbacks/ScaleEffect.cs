using System;
using UnityEngine;

namespace LemonInc.Core.Utilities.Ui.Feedbacks
{
    [Serializable]
    public class ScaleEffect : UiEffect
    {
        [SerializeField] private Vector3 _fromScale = Vector3.one;
        [SerializeField] private Vector3 _toScale = Vector3.one * 1.1f;
        
        private Transform _target;

        public ScaleEffect() {}
        public ScaleEffect(Vector3 from, Vector3 to)
        {
            _fromScale = from;
            _toScale = to;
        }

        public override void Initialize(Transform target)
        {
            _target = target;
        }

        public override void Apply(float progress)
        {
            if (_target != null)
            {
                _target.localScale = Vector3.Lerp(_fromScale, _toScale, progress);
            }
        }
    }
}