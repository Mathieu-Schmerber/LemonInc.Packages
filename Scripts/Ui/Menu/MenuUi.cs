using System.Collections.Generic;
using PrimeTween;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Core.Utilities.Ui.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class MenuUi : MonoBehaviour
    {
        [Title("Transitions")]
        [SerializeField] protected float ShowDuration = 0.2f;
        [SerializeField] protected float HideDuration = 0.2f;
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
                Tween.Custom(0f, 1f, ShowDuration, v =>
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
                Tween.Custom(0, 1f, HideDuration, v =>
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
        [Sirenix.OdinInspector.Button(Name = "Show")]
        protected void ShowInEditor()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
            
            _transitions.ForEach(t =>
            {
                t.Initialize(this);
                t.EditorEnter();
            });
        }

        [Sirenix.OdinInspector.Button(Name = "Hide")]
        protected void HideInEditor()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
            
            _transitions.ForEach(t =>
            {
                t.Initialize(this);
                t.EditorExit();
            });
        }
#endif
    }
}