using UnityEngine;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
    /// <summary>
    /// Handles drag and drop gesture detection.
    /// </summary>
    public class DragDropGesture
    {
        private readonly float _minDragDistance;
        private Vector2 _dragStartPos;
        private bool _isDragging;
        
        public PhysicalInput Touched { get; private set; } = new();
        public PhysicalInputValue<Vector2, Vector2> Position { get; private set; } = new();
        
        /// <summary>
        /// Gets whether a drag is currently in progress.
        /// </summary>
        public bool IsDragging => _isDragging;
        
        /// <summary>
        /// Current drag delta from start position.
        /// </summary>
        public InputStateValue<Vector2> DragDelta { get; private set; } = new();
        
        /// <summary>
        /// Current drag direction (normalized).
        /// </summary>
        public InputStateValue<Vector2> DragDirection { get; private set; } = new();
        
        /// <summary>
        /// Distance dragged from start position.
        /// </summary>
        public InputStateValue<float> DragDistance { get; private set; } = new();
        
        /// <summary>
        /// Drag start event.
        /// </summary>
        public InputState DragStarted { get; private set; } = new();
        
        /// <summary>
        /// Drag end/drop event.
        /// </summary>
        public InputState Dropped { get; private set; } = new();
        
        /// <summary>
        /// Called when touch/click begins.
        /// </summary>
        private void OnTouchStart()
        {
            _dragStartPos = Position.Value;
            _isDragging = false;
        }
        
        /// <summary>
        /// Called while touch/click is held.
        /// </summary>
        private void OnTouchHeld()
        {
            if (!Touched.Pressed)
                return;
                
            var currentPos = Position.Value;
            var delta = currentPos - _dragStartPos;
            var distance = delta.magnitude;
            
            // Start drag if we've moved far enough
            if (!_isDragging && distance >= _minDragDistance)
            {
                _isDragging = true;
                DragStarted.Press();
            }
            
            // Update drag values if dragging
            if (_isDragging)
            {
                DragDelta.SetValue(delta);
                DragDistance.SetValue(distance);
                
                if (distance > 0.001f)
                {
                    DragDirection.SetValue(delta.normalized);
                }
            }
        }
        
        /// <summary>
        /// Called when touch/click ends.
        /// </summary>
        private void OnTouchEnd()
        {
            if (_isDragging)
            {
                Dropped.Press();
                _isDragging = false;
            }
            
            // Reset values
            DragDelta.SetValue(Vector2.zero);
            DragDistance.SetValue(0f);
            DragDirection.SetValue(Vector2.zero);
        }
        
        /// <summary>
        /// Subscribes to input actions.
        /// </summary>
        /// <param name="touchAction">The touch/click action.</param>
        /// <param name="positionAction">The position action.</param>
        public void Subscribe(InputAction touchAction, InputAction positionAction)
        {
            Touched.Subscribe(touchAction);
            Position.Subscribe(positionAction);
            
            Touched.OnPressed += OnTouchStart;
            Touched.OnReleased += OnTouchEnd;
        }

        /// <summary>
        /// Unsubscribes from input actions.
        /// </summary>
        public void UnSubscribe()
        {
            Touched.UnSubscribe();
            Position.UnSubscribe();
            
            Touched.OnPressed -= OnTouchStart;
            Touched.OnReleased -= OnTouchEnd;
        }
        
        /// <summary>
        /// Updates the drag state. Call this from Update() if you want continuous drag updates.
        /// </summary>
        public void Update()
        {
            OnTouchHeld();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DragDropGesture"/> class.
        /// </summary>
        /// <param name="minDragDistance">Minimum distance in pixels to consider a drag started.</param>
        public DragDropGesture(float minDragDistance = 10f)
        {
            _minDragDistance = minDragDistance;
        }
    }
}