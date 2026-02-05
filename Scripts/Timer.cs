using System;
using System.Collections.Generic;
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
        private bool _isPaused;
        private List<Action> _onTickCallbacks;
        private List<Action> _onStartCallbacks;
        private List<Action> _onStopCallbacks;
        private List<Action> _onPauseCallbacks;
        private List<Action> _onResumeCallbacks;
        private List<Action> _onResetCallbacks;

        /// <summary>
        /// Gets the elapsed time since the timer started, clamped to interval.
        /// </summary>
        public float ElapsedTime => Mathf.Min(_elapsedTime, _interval);

        /// <summary>
        /// Gets the remaining time until the timer finishes, clamped to 0.
        /// </summary>
        public float TimeLeft => Mathf.Max(_interval - _elapsedTime, 0f);

        /// <summary>
        /// Gets whether the timer is currently running.
        /// </summary>
        public bool IsRunning => _isRunning;

        /// <summary>
        /// Gets whether the timer is currently paused.
        /// </summary>
        public bool IsPaused => _isPaused;

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
            AddOnTickListener(onTickCallback);
            _autoReset = autoReset;
        }

        /// <summary>
        /// Starts the timer asynchronously.
        /// </summary>
        public void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _isPaused = false;
            _elapsedTime = 0f;
            _onStartCallbacks?.ForEach(callback => callback?.Invoke());
            RunTimerAsync();
        }

        private async void RunTimerAsync()
        {
            while (_isRunning)
            {
                while (_elapsedTime < _interval && _isRunning)
                {
                    await System.Threading.Tasks.Task.Yield();
                    
                    if (!_isPaused)
                    {
                        _elapsedTime += _useScaledTime ? Time.deltaTime : Time.unscaledDeltaTime;
                    }
                }

                if (!_isRunning) 
                    continue;
                
                _onTickCallbacks?.ForEach(callback => callback?.Invoke());
                
                if (_autoReset)
                    _elapsedTime = 0f;
                else
                    _isRunning = false;
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
        {
            if (!_isRunning) return;
            
            _isRunning = false;
            _isPaused = false;
            _onStopCallbacks?.ForEach(callback => callback?.Invoke());
        }

        /// <summary>
        /// Pauses the timer.
        /// </summary>
        public void Pause()
        {
            if (_isRunning && !_isPaused)
            {
                _isPaused = true;
                _onPauseCallbacks?.ForEach(callback => callback?.Invoke());
            }
        }

        /// <summary>
        /// Resumes the timer if it was paused.
        /// </summary>
        public void Resume()
        {
            if (_isRunning && _isPaused)
            {
                _isPaused = false;
                _onResumeCallbacks?.ForEach(callback => callback?.Invoke());
            }
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
            _isPaused = false;
            _onResetCallbacks?.ForEach(callback => callback?.Invoke());
        }

        /// <summary>
        /// Restarts the timer by resetting it and starting it again.
        /// </summary>
        public void Restart()
        {
            Reset();
            Start();
        }

        #region Callbacks

        /// <summary>
        /// Adds a callback to invoke every frame while the timer is running.
        /// </summary>
        public void AddOnTickListener(Action callback)
        {
            if (callback != null)
            {
                _onTickCallbacks ??= new List<Action>();
                if (!_onTickCallbacks.Contains(callback))
                    _onTickCallbacks.Add(callback);
            }
        }

        /// <summary>
        /// Removes an OnTick listener.
        /// </summary>
        public void RemoveOnTickListener(Action callback)
        {
            _onTickCallbacks?.Remove(callback);
        }

        /// <summary>
        /// Adds a callback to invoke when the timer starts.
        /// </summary>
        public void AddOnStartListener(Action callback)
        {
            if (callback != null)
            {
                _onStartCallbacks ??= new List<Action>();
                if (!_onStartCallbacks.Contains(callback))
                    _onStartCallbacks.Add(callback);
            }
        }

        /// <summary>
        /// Removes an OnStart listener.
        /// </summary>
        public void RemoveOnStartListener(Action callback)
        {
            _onStartCallbacks?.Remove(callback);
        }

        /// <summary>
        /// Adds a callback to invoke when the timer stops.
        /// </summary>
        public void AddOnStopListener(Action callback)
        {
            if (callback != null)
            {
                _onStopCallbacks ??= new List<Action>();
                if (!_onStopCallbacks.Contains(callback))
                    _onStopCallbacks.Add(callback);
            }
        }

        /// <summary>
        /// Removes an OnStop listener.
        /// </summary>
        public void RemoveOnStopListener(Action callback)
        {
            _onStopCallbacks?.Remove(callback);
        }

        /// <summary>
        /// Adds a callback to invoke when the timer is paused.
        /// </summary>
        public void AddOnPauseListener(Action callback)
        {
            if (callback != null)
            {
                _onPauseCallbacks ??= new List<Action>();
                if (!_onPauseCallbacks.Contains(callback))
                    _onPauseCallbacks.Add(callback);
            }
        }

        /// <summary>
        /// Removes an OnPause listener.
        /// </summary>
        public void RemoveOnPauseListener(Action callback)
        {
            _onPauseCallbacks?.Remove(callback);
        }

        /// <summary>
        /// Adds a callback to invoke when the timer is resumed.
        /// </summary>
        public void AddOnResumeListener(Action callback)
        {
            if (callback != null)
            {
                _onResumeCallbacks ??= new List<Action>();
                if (!_onResumeCallbacks.Contains(callback))
                    _onResumeCallbacks.Add(callback);
            }
        }

        /// <summary>
        /// Removes an OnResume listener.
        /// </summary>
        public void RemoveOnResumeListener(Action callback)
        {
            _onResumeCallbacks?.Remove(callback);
        }

        /// <summary>
        /// Adds a callback to invoke when the timer is reset.
        /// </summary>
        public void AddOnResetListener(Action callback)
        {
            if (callback != null)
            {
                _onResetCallbacks ??= new List<Action>();
                if (!_onResetCallbacks.Contains(callback))
                    _onResetCallbacks.Add(callback);
            }
        }

        /// <summary>
        /// Removes an OnReset listener.
        /// </summary>
        public void RemoveOnResetListener(Action callback)
        {
            _onResetCallbacks?.Remove(callback);
        }

        /// <summary>
        /// Adds a callback to invoke when the timer completes (reaches interval).
        /// </summary>
        public void AddOnCompleteListener(Action callback)
        {
            if (callback != null)
            {
                _onTickCallbacks ??= new List<Action>();
                if (!_onTickCallbacks.Contains(callback))
                    _onTickCallbacks.Add(callback);
            }
        }

        /// <summary>
        /// Removes an OnComplete listener.
        /// </summary>
        public void RemoveOnCompleteListener(Action callback)
        {
            _onTickCallbacks?.Remove(callback);
        }

        #endregion
    }
}