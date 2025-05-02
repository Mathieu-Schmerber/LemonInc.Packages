using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace LemonInc.Core.Utilities.Datatypes.Tween
{
    [Serializable]
    public struct TweenColor : ITweenAnimation
    {
        [InlineProperty, HideLabel] public TweenValue<Color> Value;
        
        private readonly Dictionary<Transform, Graphic> _graphics;

        public TweenColor(Color from, Color to, float duration)
        {
            Value = new TweenValue<Color>(from, to, duration);
            _graphics = new Dictionary<Transform, Graphic>();
        }

        public PrimeTween.Tween Play(Transform transform, bool useTimeScale = true)
        {
            if (!_graphics.TryGetValue(transform, out var graphic) || graphic == null)
            {
                graphic = transform.GetComponent<Graphic>();
                _graphics[transform] = graphic;
            }

            if (graphic != null)
                return Value.Play(graphic, PrimeTween.Tween.Color, useTimeScale);

            Debug.LogError($"TweenColor cannot be played, {transform} has no Graphic component.");
            return default;
        }

        public PrimeTween.Tween Reverse(Transform transform, bool useTimeScale = true)
        {
            if (!_graphics.TryGetValue(transform, out var graphic) || graphic == null)
            {
                graphic = transform.GetComponent<Graphic>();
                _graphics[transform] = graphic;
            }

            if (graphic != null)
                return Value.Reverse(graphic, PrimeTween.Tween.Color, useTimeScale);

            Debug.LogError($"TweenColor cannot be played, {transform} has no Graphic component.");
            return default;
        }
    }
}