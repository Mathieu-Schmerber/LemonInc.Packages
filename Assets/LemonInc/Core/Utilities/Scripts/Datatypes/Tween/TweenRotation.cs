using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Core.Utilities.Datatypes.Tween
{
    [Serializable]
    public struct TweenRotation : ITweenAnimation
    {
        [InlineProperty, HideLabel] public TweenValue<Vector3> Value;

        public TweenRotation(Vector3 from, Vector3 to, float duration)
        {
            Value = new TweenValue<Vector3>(from, to, duration);
        }
        
        public PrimeTween.Tween Play(Transform transform) => Value.Play(transform, PrimeTween.Tween.LocalRotation);
        public PrimeTween.Tween Reverse(Transform transform) => Value.Reverse(transform, PrimeTween.Tween.LocalRotation);
    }
}