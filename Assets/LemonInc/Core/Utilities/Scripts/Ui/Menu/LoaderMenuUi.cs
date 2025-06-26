using System;
using System.Collections;

namespace LemonInc.Core.Utilities.Ui.Menu
{
    public class LoaderMenuUi : MenuUi
    {
        public override bool IsBlocking => true;
        
        private Action _fadeOutCallback;
        private Func<IEnumerator> _fadeInCallback;
        private float _baseShowDuration;
        private float _baseHideDuration;

        protected override void Awake()
        {
            base.Awake();
            _baseShowDuration = ShowDuration;
            _baseHideDuration = HideDuration;
        }
        
        /// <summary>
        /// Initiates a menu transition sequence with callbacks.
        /// </summary>
        /// <param name="onFadedIn">Coroutine delegate that gets executed after the menu fades in.</param>
        /// <param name="onFadedOut">Optional callback that gets invoked after the menu fades out.</param>
        /// <param name="transitionDuration">If not set, the default in-editor duration will be used.</param>
        public void RunWithTransition(Func<IEnumerator> onFadedIn, Action onFadedOut = null, float transitionDuration = -1)
        {
            ShowDuration = transitionDuration >= 0 ? transitionDuration : _baseShowDuration;
            HideDuration = transitionDuration >= 0 ? transitionDuration : _baseHideDuration;

            _fadeInCallback = onFadedIn;
            _fadeOutCallback = onFadedOut;
            ShowMenu();
        }

        protected override void OnShowMenu()
        {
            base.OnShowMenu();
            if (_fadeInCallback != null)
                StartCoroutine(FadeInThenHide());
            else
                HideMenu();
            return;

            IEnumerator FadeInThenHide()
            {
                yield return StartCoroutine(_fadeInCallback());
                HideMenu();
            }
        }

        protected override void OnHideMenu()
        {
            base.OnHideMenu();
            _fadeOutCallback?.Invoke();
        }
    }
}