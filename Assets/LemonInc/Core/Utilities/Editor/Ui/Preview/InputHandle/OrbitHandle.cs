using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Ui.Preview.InputHandle
{
    /// <summary>
    /// Orbits around a center point by dragging while pressing right click.
    /// </summary>
    public class OrbitHandle : IEventHandleStrategy
    {
        private bool _isRightMouseButtonDown;
        
        public Vector3 OrbitCenter { get; set; }
        public bool Active { get; set; }
    
        public bool ConsumeEvent(IEditorPreview preview, Event current)
        {
            if (!Active || preview?.Camera == null)
                return false;

            switch (current.type)
            {
                case EventType.MouseDown when current.button == 1:
                    _isRightMouseButtonDown = true;
                    break;
                case EventType.MouseUp when current.button == 1:
                    _isRightMouseButtonDown = false;
                    break;
                case EventType.MouseDrag when _isRightMouseButtonDown:
                    if (current.delta.sqrMagnitude > 0)
                        RotateCamera(preview.Camera.transform, current.delta);
                    break; 
                default:
                    return false;
            }

            return true;
        }

        private void RotateCamera(Transform cameraTransform, Vector2 delta)
        {
            var mouseX = delta.x;
            var mouseY = delta.y;

            cameraTransform.RotateAround(OrbitCenter, Vector3.up, mouseX);
            cameraTransform.RotateAround(OrbitCenter, cameraTransform.right, mouseY);
            cameraTransform.LookAt(OrbitCenter);
        }

        public void Dispose() { }
    }
}