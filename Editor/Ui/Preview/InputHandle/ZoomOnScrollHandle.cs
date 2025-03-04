using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Ui.Preview.InputHandle
{ 
    /// <summary>
    /// Zooms in an out with the scroll-wheel. 
    /// </summary>
    public class ZoomOnScrollHandle : IEventHandleStrategy
    {
        public float CameraDistance { get; set; } = 10f;
        public float MaxZoomDistance { get; set; } = 50f;
        public float MinZoomDistance { get; set; } = 1f;
        public float ZoomSensitivity { get; set; } = .1f;
        public float OrthoZoomSensitivity { get; set; } = .5f;

        private float _targetCameraDistance;

        public bool Active { get; set; }

        public ZoomOnScrollHandle()
        {
            _targetCameraDistance = CameraDistance;
        }

        public bool ConsumeEvent(IEditorPreview preview, Event current)
        {
            if (preview.Camera == null || current.type != EventType.ScrollWheel)
                return false;

            var scrollDelta = current.delta.y;
            var camera = preview.Camera;

            if (camera.orthographic)
            {
                camera.orthographicSize += scrollDelta * OrthoZoomSensitivity;
                camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, MinZoomDistance, MaxZoomDistance);
            }
            else
            {
                _targetCameraDistance += scrollDelta * ZoomSensitivity;
                _targetCameraDistance = Mathf.Clamp(_targetCameraDistance, MinZoomDistance, MaxZoomDistance);

                CameraDistance = _targetCameraDistance;
                camera.transform.position = camera.transform.forward * -CameraDistance;
            }

            return true;
        }

        public void Dispose() { }
    }
}