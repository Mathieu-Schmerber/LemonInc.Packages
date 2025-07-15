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
        
#if UNITY_EDITOR
        public virtual void EditorEnter() {}
        public virtual void EditorExit() {}
#endif
    }
    
    [Serializable]
    public class FadeMenuTransition : MenuTransition
    {
        [SerializeField] private bool _disableAfterHide = true;
        
        private CanvasGroup _canvasGroup;

        public override void Initialize(MenuUi menu)
        {
            base.Initialize(menu);
            _canvasGroup = menu.GetComponent<CanvasGroup>();
        }

        public override void OnShowTransition(float progress)
        {
            if (_disableAfterHide)
                _canvasGroup.gameObject.SetActive(true);
            _canvasGroup.alpha = progress;
        }
        
        public override void OnHideTransition(float progress)
        {
            _canvasGroup.alpha = 1f - progress;
        }
        
        public override void OnShowTransitionCompleted()
        {
            _canvasGroup.alpha = 1f;
            if (_disableAfterHide)
                _canvasGroup.gameObject.SetActive(true);
        }

        public override void OnHideTransitionCompleted()
        {
            _canvasGroup.alpha = 0f;
            if (_disableAfterHide)
                _canvasGroup.gameObject.SetActive(false);
        }

#if UNITY_EDITOR
        public override void EditorEnter()
        {
            _canvasGroup.alpha = 1f;
            if (_disableAfterHide)
                _canvasGroup.gameObject.SetActive(true);
        }

        public override void EditorExit()
        {
            _canvasGroup.alpha = 0f;
            if (_disableAfterHide)
                _canvasGroup.gameObject.SetActive(false);
        }
#endif
    }
    
    [Serializable]
    public class SlideMenuTransition : MenuTransition
    {
        [SerializeField] private Vector3 _enterPosition = Vector3.zero;
        [SerializeField] private Vector3 _exitPosition = new(0, -1000, 0);
    
        private RectTransform _rectTransform;

        public override void Initialize(MenuUi menu)
        {
            base.Initialize(menu);
            _rectTransform = menu.GetComponent<RectTransform>();
        }

        public override void OnShowTransition(float progress)
        {
            if (_rectTransform != null)
                _rectTransform.anchoredPosition = Vector3.Lerp(_exitPosition, _enterPosition, progress);
        }
    
        public override void OnShowTransitionCompleted()
        {
            if (_rectTransform != null)
                _rectTransform.anchoredPosition = _enterPosition;
        }

        public override void OnHideTransition(float progress)
        {
            if (_rectTransform != null)
                _rectTransform.anchoredPosition = Vector3.Lerp(_enterPosition, _exitPosition, progress);
        }
    
        public override void OnHideTransitionCompleted()
        {
            if (_rectTransform != null)
                _rectTransform.anchoredPosition = _exitPosition;
        }
    
#if UNITY_EDITOR
        public override void EditorEnter()
        {
            if (_rectTransform != null)
                _rectTransform.anchoredPosition = _enterPosition;
        }
    
        public override void EditorExit()
        {
            if (_rectTransform != null)
                _rectTransform.anchoredPosition = _exitPosition;
        }
#endif
    }
}