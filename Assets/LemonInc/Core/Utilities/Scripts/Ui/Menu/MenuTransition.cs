using System;
using UnityEngine;

namespace LemonInc.Core.Utilities.Ui.Menu
{
    [Serializable]
    public abstract class MenuTransition
    {
        public virtual void Initialize(MenuUi menu) {}
        
        public virtual void OnShowTransition(float progress) {}
		public virtual void OnShowTransitionCompleted() {}

        public virtual void OnHideTransition(float progress) {}
        public virtual void OnHideTransitionCompleted() {}
    }
    
    [Serializable]
    public class FadeMenuTransition : MenuTransition
    {
        private CanvasGroup _canvasGroup;

        public override void Initialize(MenuUi menu)
        {
            base.Initialize(menu);
            _canvasGroup = menu.GetComponent<CanvasGroup>();
        }

        public override void OnShowTransition(float progress)
        {
            _canvasGroup.alpha = progress;
        }
        
        public override void OnHideTransition(float progress)
        {
            _canvasGroup.alpha = progress;
        }
    }
    
    [Serializable]
    public class SlideMenuTransition : MenuTransition
    {
        public enum SlideDirection
        {
            Left,
            Right,
            Up,
            Down
        }
        
        [SerializeField] private SlideDirection _slideDirection = SlideDirection.Left;
        [SerializeField] private float _slideDistance = 1000f;
        
        private RectTransform _rectTransform;
        private Vector2 _hiddenPosition;
        private Vector2 _visiblePosition;

        public override void Initialize(MenuUi menu)
        {
            base.Initialize(menu);
            _rectTransform = menu.GetComponent<RectTransform>();
            _visiblePosition = _rectTransform.anchoredPosition;

            _hiddenPosition = _slideDirection switch
            {
                SlideDirection.Left => _visiblePosition + Vector2.left * _slideDistance,
                SlideDirection.Right => _visiblePosition + Vector2.right * _slideDistance,
                SlideDirection.Up => _visiblePosition + Vector2.up * _slideDistance,
                SlideDirection.Down => _visiblePosition + Vector2.down * _slideDistance,
                _ => _hiddenPosition
            };
        }

        public override void OnShowTransition(float progress)
        {
            _rectTransform.anchoredPosition = Vector2.Lerp(_hiddenPosition, _visiblePosition, progress);
        }
        
        public override void OnHideTransition(float progress)
        {
            _rectTransform.anchoredPosition = Vector2.Lerp(_visiblePosition, _hiddenPosition, progress);
        }
    }
}