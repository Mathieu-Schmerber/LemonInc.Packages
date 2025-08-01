using LemonInc.Core.Utilities.Extensions;
using PrimeTween;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LemonInc.Core.Utilities.Ui.Feedbacks
{
    public class UiFeedbacks : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerDownHandler,
        IPointerUpHandler
    {
        [Title("Hover Effects")]
        [SerializeField] private float _hoverDuration = 0.1f;
        [SerializeReference] private UiEffect[] _hoverEffects = {
            new ScaleEffect(Vector3.one, Vector3.one * 1.1f),
            new ColorEffect((Color.white * .8f).WithAlpha(1), ColorBlendMode.Multiplicative)
        };

        [Title("Click Effects")]
        [SerializeField] private float _clickDuration = 0.1f;
        [SerializeReference] private UiEffect[] _clickEffects = {
            new ScaleEffect(Vector3.one, Vector3.one * .9f),
            new ColorEffect((Color.white * .6f).WithAlpha(1), ColorBlendMode.Multiplicative)
        };

        private Tween _hoverTween;
        private Tween _clickTween;

        private void Start()
        {
            foreach (var effect in _hoverEffects)
                effect.Initialize(transform);
            
            foreach (var effect in _clickEffects)
                effect.Initialize(transform);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _hoverTween.Stop();
            _hoverTween = Tween.Custom(0f, 1f, _hoverDuration, progress =>
            {
                foreach (var effect in _hoverEffects)
                {
                    effect.Apply(progress);
                }
            });
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _hoverTween.Stop();
            _hoverTween = Tween.Custom(1f, 0f, _hoverDuration, progress =>
            {
                foreach (var effect in _hoverEffects)
                {
                    effect.Apply(progress);
                }
            });
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _clickTween.Stop();
            _clickTween = Tween.Custom(0f, 1f, _clickDuration, progress =>
            {
                foreach (var effect in _clickEffects)
                {
                    effect.Apply(progress);
                }
            });
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _clickTween.Stop();
            _clickTween = Tween.Custom(1f, 0f, _clickDuration, progress =>
            {
                foreach (var effect in _clickEffects)
                {
                    effect.Apply(progress);
                }
            });
        }
    }
}