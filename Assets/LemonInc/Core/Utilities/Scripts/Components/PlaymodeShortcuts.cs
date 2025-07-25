using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace LemonInc.Core.Utilities.Components
{
    public class PlaymodeShortcuts : MonoBehaviour
    {
        [Title("Scene Reload")]
        [ToggleGroup("_reloadScene", "Reload Scene", CollapseOthersOnExpand = false)]
        public bool _reloadScene = true;
        
        [ToggleGroup("_reloadScene")]
        [LabelText("Shortcut Keys")]
        [ValidateInput("ValidateShortcutKeys", "Shortcut must have at least one key")]
        public Key[] _reloadSceneShortcuts = new[] { Key.LeftCtrl, Key.R };
        
        [Space]
        [Title("Game Pause")]
        [ToggleGroup("_pauseGame", "Pause", CollapseOthersOnExpand = false)]
        public bool _pauseGame = true;
        
        [ToggleGroup("_pauseGame")]
        [LabelText("Shortcut Keys")]
        [ValidateInput("ValidateShortcutKeys", "Shortcut must have at least one key")]
        public Key[] _pauseShortcuts = new[] { Key.LeftCtrl, Key.P };

        private void Update()
        {
            if (_reloadScene && _reloadSceneShortcuts.All(x => Keyboard.current[x].isPressed))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (_pauseGame && _pauseShortcuts.All(x => Keyboard.current[x].isPressed))
            {
                Debug.Break();
            }
        }

        private bool ValidateShortcutKeys(Key[] keys)
        {
            return keys is { Length: > 0 };
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_reloadSceneShortcuts.Length == 0 && _pauseShortcuts.Length == 0)
                Reset();
        }
        
        private void Reset()
        {
            _reloadSceneShortcuts = new[] { Key.LeftCtrl, Key.R };
            _pauseShortcuts = new[] { Key.LeftCtrl, Key.P };
        }
#endif
    }
}