using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Core.Utilities.Datatypes.Tween
{
    [Serializable]
    public struct TweenOffsetPosition : ITweenAnimation
    {
        [InlineProperty, HideLabel] public TweenValue<Vector3> Value;

        private readonly Dictionary<Transform, Vector3> _positions;
        
        public TweenOffsetPosition(Vector3 from, Vector3 to, float duration)
        {
            Value = new TweenValue<Vector3>(from, to, duration);
            _positions = new();
        }

        public PrimeTween.Tween Play(Transform transform)
        {
            if (!_positions.TryGetValue(transform, out var initialPosition))
            {
                initialPosition = transform.position;
                _positions[transform] = initialPosition;
            }

            return PrimeTween.Tween.LocalPosition(transform, initialPosition, initialPosition + Value.From, Value.Duration, Value.EaseIn, startDelay: Value.Delay);
        }
        
        public PrimeTween.Tween Reverse(Transform transform)
        {
            if (!_positions.TryGetValue(transform, out var initialPosition))
            {
                initialPosition = transform.position;
                _positions[transform] = initialPosition;
            }
            
            return PrimeTween.Tween.LocalPosition(transform, initialPosition, initialPosition + Value.To, Value.Duration, Value.EaseOut, startDelay: Value.Delay);
        }
    }
}