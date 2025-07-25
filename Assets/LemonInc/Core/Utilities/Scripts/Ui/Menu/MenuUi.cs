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
        
        [Title("Behavior")]
        [SerializeField] private bool _disableGameObjectWhenHidden = true;
        
        protected CanvasGroup CanvasGroup;
        private bool _hidden = true;

        public abstract bool IsBlocking { get; }
        public bool IsVisible => !_hidden;

        protected virtual void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            _transitions.ForEach(t => t.Initialize(this));
        }

        protected virtual void Start()
        {
            _hidden = !CanvasGroup.interactable;
        }
        
        public void ShowMenu(float transitionTime = -1f)
        {
            if (_hidden)
            {
                _hidden = false;
                
                if (_disableGameObjectWhenHidden)
                    gameObject.SetActive(true);
                
                CanvasGroup.interactable = true;
                CanvasGroup.blocksRaycasts = true;
                OnBeforeShow();
                
                var duration = transitionTime >= 0f ? transitionTime : ShowDuration;
                Tween.Custom(0f, 1f, duration, v =>
                {
                    _transitions.ForEach(t => t.OnShowTransition(v));
                }).OnComplete(() =>
                {
                    _transitions.ForEach(t => t.OnShowTransitionCompleted());
                    OnShowMenu();
                });
            }
        }

        public void HideMenu(float transitionTime = -1f)
        {
            if (!_hidden)
            {
                _hidden = true;
                CanvasGroup.interactable = false;
                CanvasGroup.blocksRaycasts = false;
                OnBeforeHide();
                
                var duration = transitionTime >= 0f ? transitionTime : HideDuration;
                Tween.Custom(0, 1f, duration, v =>
                {
                    _transitions.ForEach(t => t.OnHideTransition(v));
                }).OnComplete(() =>
                {
                    _transitions.ForEach(t => t.OnHideTransitionCompleted());
                    OnHideMenu();
                    
                    if (_disableGameObjectWhenHidden)
                        gameObject.SetActive(false);
                });
            }
        }
        
        protected virtual void OnBeforeShow() { }
        protected virtual void OnShowMenu() { }
        
        protected virtual void OnBeforeHide() { }
        protected virtual void OnHideMenu() { }
        
#if UNITY_EDITOR
        [Sirenix.OdinInspector.Button(Name = "Show")]
        protected void ShowInEditor()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
            
            if (_disableGameObjectWhenHidden)
            {
                gameObject.SetActive(true);
            }
            
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
            
            if (_disableGameObjectWhenHidden)
            {
                gameObject.SetActive(false);
            }
        }
#endif
    }
}