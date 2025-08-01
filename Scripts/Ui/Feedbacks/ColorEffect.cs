using System;
using UnityEngine;

namespace LemonInc.Core.Utilities.Ui.Feedbacks
{
    [Serializable]
    public enum ColorBlendMode
    {
        Set,
        Additive,
        Multiplicative,
        Subtractive
    }

    [Serializable]
    public class ColorEffect : UiEffect
    {
        [SerializeField] private Color _effectColor = new(.9f, .9f, .9f);
        [SerializeField] private ColorBlendMode _blendMode = ColorBlendMode.Set;
        
        private Transform _target;
        private UnityEngine.UI.Graphic _graphic;
        private Color _originalColor;

        public ColorEffect() { }
        public ColorEffect(Color effectColor, ColorBlendMode blendMode = ColorBlendMode.Set)
        {
            _effectColor = effectColor;
            _blendMode = blendMode;
        }

        public override void Initialize(Transform target)
        {
            _target = target;
            _graphic = target.GetComponent<UnityEngine.UI.Graphic>();
            if (_graphic != null)
            {
                _originalColor = _graphic.color;
            }
        }

        public override void Apply(float progress)
        {
            if (_graphic == null) 
                return;
            
            Color targetColor;
            switch (_blendMode)
            {
                case ColorBlendMode.Set:
                    targetColor = Color.Lerp(_originalColor, _effectColor, progress);
                    break;
                case ColorBlendMode.Additive:
                    targetColor = _originalColor + (_effectColor * progress);
                    break;
                case ColorBlendMode.Multiplicative:
                    Color multiplier = Color.Lerp(Color.white, _effectColor, progress);
                    targetColor = new Color(
                        _originalColor.r * multiplier.r,
                        _originalColor.g * multiplier.g,
                        _originalColor.b * multiplier.b,
                        _originalColor.a * multiplier.a
                    );
                    break;
                case ColorBlendMode.Subtractive:
                    targetColor = _originalColor - (_effectColor * progress);
                    break;
                default:
                    targetColor = _originalColor;
                    break;
            }
                
            _graphic.color = targetColor;
        }
    }
}