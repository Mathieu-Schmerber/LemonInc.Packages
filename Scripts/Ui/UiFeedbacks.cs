using System;
using LemonInc.Core.Utilities.Datatypes.Tween;
using PrimeTween;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LemonInc.Core.Utilities.Ui
{
    public class UiFeedbacks : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerDownHandler,
        IPointerUpHandler
    {
        [Title("Hover")] [SerializeField] private TweenScale _scaleOnHover = new(Vector3.one, Vector3.one * 1.1f, 0.1f);
        [SerializeField] private TweenColor _colorOnHover = new(Color.white, new Color(.9f, .9f, .9f), 0.1f);

        [Title("Click")]
        [SerializeField] private TweenScale _scaleOnClick = new(Vector3.one, Vector3.one * .9f, 0.1f);
        [SerializeField] private TweenColor _colorOnClick = new(Color.white, new Color(.8f, .8f, .8f), 0.1f);

        public void OnPointerEnter(PointerEventData eventData)
        {
            _scaleOnHover.Play(transform);
            _colorOnHover.Play(transform);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _scaleOnHover.Reverse(transform);
            _colorOnHover.Reverse(transform);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _scaleOnClick.Play(transform);
            _colorOnClick.Play(transform);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _scaleOnClick.Reverse(transform);
            _colorOnClick.Reverse(transform);
        }
    }
}