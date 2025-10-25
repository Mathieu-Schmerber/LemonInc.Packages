using UnityEngine;

namespace LemonInc.Core.Utilities.Singletons
{
    /// <summary>
    /// Singleton <see cref="MonoBehaviour"/> that persists in between scene loads.
    /// </summary>
    public abstract class PersistentSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) 
                    return _instance;
                
                _instance = FindAnyObjectByType<T>();
                if (_instance != null) 
                    return _instance;
                
                var singletonObject = new GameObject(typeof(T).Name);
                _instance = singletonObject.AddComponent<T>();
                return _instance;
            }
        }

        protected virtual void Awake()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#endif

            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (_instance != this)
                    Destroy(gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
#endif

            if (_instance == this)
            {
                _instance = null;
            }
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