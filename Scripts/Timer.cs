using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Core.Utilities
{
    [Serializable, InlineProperty]
    public class Timer
    {
        [SerializeField] private float _interval;
        [SerializeField] private float _elapsedTime;
        
        private bool _useScaledTime;
        private bool _autoReset;
        private bool _isRunning;
        private Action _onTickCallback;

        /// <summary>
        /// Gets the elapsed time since the timer started.
        /// </summary>
        public float ElapsedTime => _elapsedTime;

        /// <summary>
        /// Gets the remaining time until the timer finishes.
        /// </summary>
        public float TimeLeft => _interval - _elapsedTime;

        /// <summary>
        /// Gets whether the timer is currently running.
        /// </summary>
        public bool IsRunning => _isRunning;

        /// <summary>
        /// Gets or sets the interval (duration) of the timer.
        /// </summary>
        public float Interval
        {
            get => _interval;
            set => _interval = value;
        }

        /// <summary>
        /// Initializes a new instance of the Timer class.
        /// </summary>
        public Timer(float interval = 1f, bool useScaledTime = true, Action onTickCallback = null, bool autoReset = false)
        {
            _interval = interval;
            _useScaledTime = useScaledTime;
            _onTickCallback = onTickCallback;
            _autoReset = autoReset;
        }

        /// <summary>
        /// Starts the timer asynchronously.
        /// </summary>
        public void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _elapsedTime = 0f;
            RunTimerAsync();
        }

        private async void RunTimerAsync()
        {
            while (_isRunning)
            {
                while (_elapsedTime < _interval && _isRunning)
                {
                    await System.Threading.Tasks.Task.Yield();
                    _elapsedTime += _useScaledTime ? Time.deltaTime : Time.unscaledDeltaTime;
                    _onTickCallback?.Invoke();
                }

                if (_isRunning)
                {
                    if (_autoReset)
                    {
                        _onTickCallback?.Invoke(); // Trigger the callback on auto-reset
                        _elapsedTime = 0f; // Reset elapsed time for the next cycle
                    }
                    else
                    {
                        _isRunning = false; // Stop the timer if autoReset is false
                    }
                }
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
        }

        /// <summary>
        /// Checks if the timer has finished running.
        /// </summary>
        public bool IsOver()
        {
            return _elapsedTime >= _interval || !_isRunning;
        }

        /// <summary>
        /// Resets the timer to its initial state.
        /// </summary>
        public void Reset()
        {
            _elapsedTime = 0f;
            _isRunning = false;
        }

        /// <summary>
        /// Restarts the timer by resetting it and starting it again.
        /// </summary>
        public void Restart()
        {
            Reset();
            Start();
        }

        /// <summary>
        /// Sets or updates the callback to invoke every frame while the timer is running.
        /// </summary>
        public void SetOnTickCallback(Action onTickCallback)
        {
            _onTickCallback = onTickCallback;
        }
    }
}