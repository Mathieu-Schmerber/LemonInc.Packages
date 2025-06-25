using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

namespace LemonInc.Core.Utilities.Ui.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class MenuUi : MonoBehaviour
    {
        [SerializeField] private float _showDuration = 0.2f;
        [SerializeField] private float _hideDuration = 0.2f;
        [SerializeReference] private List<MenuTransition> _transitions;
        
        protected CanvasGroup CanvasGroup;
        private bool _hidden = true;

        public abstract bool IsBlocking { get; }
        public bool IsVisible => !_hidden;

        protected virtual void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            _hidden = !CanvasGroup.interactable;
            _transitions.ForEach(t => t.Initialize(this));
        }
        
        public void ShowMenu()
        {
            if (_hidden)
            {
                _hidden = false;
                CanvasGroup.interactable = true;
                CanvasGroup.blocksRaycasts = true;
                Tween.Custom(0f, 1f, _showDuration, v =>
                {
                    _transitions.ForEach(t => t.OnShowTransition(v));
                }).OnComplete(() =>
                {
                    _transitions.ForEach(t => t.OnShowTransitionCompleted());
                    OnShowMenu();
                });
            }
        }

        public void HideMenu()
        {
            if (!_hidden)
            {
                _hidden = true;
                CanvasGroup.interactable = false;
                CanvasGroup.blocksRaycasts = false;
                Tween.Custom(1f, 0f, _hideDuration, v =>
                {
                    _transitions.ForEach(t => t.OnHideTransition(v));
                }).OnComplete(() =>
                {
                    _transitions.ForEach(t => t.OnHideTransitionCompleted());
                    OnHideMenu();
                });
            }
        }
        
        protected virtual void OnShowMenu() { }
        protected virtual void OnHideMenu() { }
        
#if UNITY_EDITOR
        [Sirenix.OdinInspector.Button]
        private void Show()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
            CanvasGroup.alpha = 1;
        }

        [Sirenix.OdinInspector.Button]
        private void Hide()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
            CanvasGroup.alpha = 0;
        }
#endif
    }
}