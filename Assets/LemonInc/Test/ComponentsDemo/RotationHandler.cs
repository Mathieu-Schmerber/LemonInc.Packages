using UnityEngine;
using UnityEngine.UI;

namespace LemonInc.Test.ComponentsDemo
{
    public class RotationHandler : MonoBehaviour
    {
        [SerializeField] private CubeHandler _cubeHandler;
        [SerializeField] private Button _lockBtn;
        [SerializeField] private Button _toggleBtn;

        private void Start()
        {
            _lockBtn.onClick.AddListener(OnLockBtnClick);
            _toggleBtn.onClick.AddListener(OnToggleBtnClick);
        }

        private void OnLockBtnClick()
        {
            if (_cubeHandler.ShouldRotate.Locked)
                _cubeHandler.ShouldRotate.Unlock();
            else
                _cubeHandler.ShouldRotate.Lock();
        }

        private void OnToggleBtnClick()
        {
            _cubeHandler.ShouldRotate.Value = !_cubeHandler.ShouldRotate;
        }
    }
}
