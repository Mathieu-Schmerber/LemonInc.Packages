using UnityEngine;

namespace LemonInc.Core.Utilities.Singletons
{
    /// <summary>
    /// Defines a Singleton. <br/>
    /// This Singleton will NOT create a new object if it does not exist and is bound to its scene.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SceneSingleton<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// The instance.
        /// </summary>
        private static T _instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = GameObject.FindObjectOfType<T>(includeInactive: false);
                return _instance;
            }
        }

        /// <summary>
        /// Called when the script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#endif
        }

        /// <summary>
        /// Called when the object is destroyed.
        /// </summary>
        protected virtual void OnDestroy()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
#endif
        }

#if UNITY_EDITOR
        /// <summary>
        /// Resets the singleton instance when exiting play mode to prevent stale references.
        /// </summary>
        private static void OnPlayModeStateChanged(UnityEditor.PlayModeStateChange state)
        {
            if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode)
            {
                _instance = null;
            }
        }
#endif
    }
}