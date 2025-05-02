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
        
        public PrimeTween.Tween Play(Transform transform, bool useTimeScale = true) => Value.Play(transform, PrimeTween.Tween.LocalRotation, useTimeScale);
        public PrimeTween.Tween Reverse(Transform transform, bool useTimeScale = true) => Value.Reverse(transform, PrimeTween.Tween.LocalRotation, useTimeScale);
    }
}