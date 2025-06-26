using UnityEngine;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
    public class TouchInput
    {
        private readonly float _maxSwipeTime;
        private readonly float _minSwipeDistance;
        private float _touchStartTime;
        private Vector2 _touchStartPos;
        
        public PhysicalInput Touched { get; private set; } = new();
        public PhysicalInputValue<Vector2, Vector2> Position { get; private set; } = new();
        
        public InputStateValue<Vector2> Swipe { get; private set; } = new();
        
        public InputState SwipeUp { get; private set; } = new();
        public InputState SwipeDown { get; private set; } = new();
        public InputState SwipeLeft { get; private set; } = new();
        public InputState SwipeRight { get; private set; } = new();
        
        private void OnTouchStart()
        {
            _touchStartTime = Time.time;
            _touchStartPos = Position.Value;
        }
        
        private void OnTouchEnd()
        {
            var swipeTime = Time.time - _touchStartTime;
            var swipeVector = Position.Value - _touchStartPos;
            var swipeDistance = swipeVector.magnitude;
    
            if (!(swipeTime <= _maxSwipeTime) || !(swipeDistance >= _minSwipeDistance)) 
                return;
            
            var swipeDirection = swipeVector.normalized;
            
            Swipe.SetValue(swipeVector);
        
            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                // Horizontal swipe
                if (swipeDirection.x > 0)
                    SwipeRight.Press();
                else
                    SwipeLeft.Press();
            }
            else
            {
                // Vertical swipe
                if (swipeDirection.y > 0)
                    SwipeUp.Press();
                else
                    SwipeDown.Press();
            }
        }
        
        public void Subscribe(InputAction touchAction, InputAction positionAction)
        {
            Touched.Subscribe(touchAction);
            Position.Subscribe(positionAction);
            
            Touched.OnPressed += OnTouchStart;
            Touched.OnReleased += OnTouchEnd;
        }

        public void UnSubscribe()
        {
            Touched.UnSubscribe();
            Position.UnSubscribe();
            
            Touched.OnPressed -= OnTouchStart;
            Touched.OnReleased -= OnTouchEnd;
        }

        public TouchInput(float maxSwipeTime = 1f, float minSwipeDistance = 100f)
        {
            _maxSwipeTime = maxSwipeTime;
            _minSwipeDistance = minSwipeDistance;
        }
    }
}