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
        [SerializeField] protected bool UnscaledTime = false;
        [SerializeReference] private List<MenuTransition> _transitions = new()
        {
            new FadeMenuTransition()
        };

        protected CanvasGroup CanvasGroup;
        private bool _hidden = true;

        public abstract bool IsBlocking { get; }
        public bool IsVisible => !_hidden;

        private Tween _activeTween;

        private bool _cancelShowRequested = false;
        private bool _cancelHideRequested = false;

        protected virtual void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            _transitions.ForEach(t => t.Initialize(this));
        }

        protected virtual void Start()
        {
            _hidden = !CanvasGroup.interactable;
        }

        public void CancelShow()
        {
            if (_hidden == false) return; // Already visible
            _cancelShowRequested = true;

            // Kill tween before it finishes
            _activeTween.Stop();
        }

        public void CancelHide()
        {
            if (_hidden == true) return; // Already hidden
            _cancelHideRequested = true;

            _activeTween.Stop();
        }

        public void ShowMenu(float transitionTime = -1f, bool? unscaledTime = null)
        {
            if (_hidden)
            {
                _cancelShowRequested = false; // Reset

                // Give subclass a chance to cancel BEFORE starting transitions
                OnBeforeShow();
                if (_cancelShowRequested)
                {
                    _hidden = true;
                    CanvasGroup.interactable = false;
                    CanvasGroup.blocksRaycasts = false;
                    return;
                }

                _hidden = false;

                CanvasGroup.interactable = true;
                CanvasGroup.blocksRaycasts = true;

                var duration = transitionTime >= 0f ? transitionTime : ShowDuration;

                _activeTween = Tween.Custom(
                    0f, 1f, duration, 
                    v =>
                    {
                        if (_cancelShowRequested)
                        {
                            _activeTween.Stop();
                            return;
                        }
                        _transitions.ForEach(t => t.OnShowTransition(v));
                    },
                    useUnscaledTime: unscaledTime ?? UnscaledTime
                )
                .OnComplete(() =>
                {
                    if (_cancelShowRequested)
                    {
                        // Re-hide instantly
                        CanvasGroup.interactable = false;
                        CanvasGroup.blocksRaycasts = false;
                        _hidden = true;
                        return;
                    }

                    _transitions.ForEach(t => t.OnShowTransitionCompleted());
                    OnShowMenu();
                });
            }
        }

        public void HideMenu(float transitionTime = -1f, bool? unscaledTime = null)
        {
            if (!_hidden)
            {
                _cancelHideRequested = false;

                OnBeforeHide();
                if (_cancelHideRequested)
                {
                    return;
                }

                _hidden = true;
                CanvasGroup.interactable = false;
                CanvasGroup.blocksRaycasts = false;

                var duration = transitionTime >= 0f ? transitionTime : HideDuration;

                _activeTween = Tween.Custom(
                    0f, 1f, duration,
                    v =>
                    {
                        if (_cancelHideRequested)
                        {
                            _activeTween.Stop();
                            return;
                        }
                        _transitions.ForEach(t => t.OnHideTransition(v));
                    },
                    useUnscaledTime: unscaledTime ?? UnscaledTime
                )
                .OnComplete(() =>
                {
                    if (_cancelHideRequested)
                    {
                        // Undo hidden state
                        _hidden = false;
                        CanvasGroup.interactable = true;
                        CanvasGroup.blocksRaycasts = true;
                        return;
                    }

                    _transitions.ForEach(t => t.OnHideTransitionCompleted());
                    OnHideMenu();
                });
            }
        }

        protected virtual void OnBeforeShow() { }
        protected virtual void OnShowMenu() { }

        protected virtual void OnBeforeHide() { }
        protected virtual void OnHideMenu() { }


#if UNITY_EDITOR
        [Button(Name = "Show")]
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

        [Button(Name = "Hide")]
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
