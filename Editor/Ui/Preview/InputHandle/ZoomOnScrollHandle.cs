using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Ui.Preview.InputHandle
{
    public class ZoomOnScroll : IInputHandleStrategy
    {
        public float CameraDistance { get; set; } = 10f;
        public float MaxZoomDistance { get; set; } = 50f;
        public float MinZoomDistance { get; set; } = 1f;
        public float ZoomSensitivity { get; set; } = .1f;

        private float _targetCameraDistance;

        public bool Active { get; set; }

        public ZoomOnScroll()
        {
            _targetCameraDistance = CameraDistance;
        }

        public void OnInput(IEditorPreview preview, Event current)
        {
            if (!Active || preview.Camera == null) return;

            var scrollDelta = current.delta.y;

            _targetCameraDistance += scrollDelta * ZoomSensitivity;
            _targetCameraDistance = Mathf.Clamp(_targetCameraDistance, MinZoomDistance, MaxZoomDistance);

            CameraDistance = _targetCameraDistance;
            preview.Camera.transform.position = preview.Camera.transform.forward * -CameraDistance;
        }

        public void Dispose() { }
    }
    
    public class OrbitHandle
}