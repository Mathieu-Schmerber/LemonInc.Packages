using System;
using UnityEngine;

namespace LemonInc.Core.Utilities.Datatypes
{
    /// <summary>
    /// Wraps a value and notifies subscribers when it changes.
    /// Inspector modifications in play mode also trigger subscriptions.
    /// </summary>
    [Serializable]
    public class Observable<T> : ISerializationCallbackReceiver
    {
        /// <summary>
        /// Delegate for value change events.
        /// </summary>
        public delegate void ValueChangedDelegate(T old, T current, T delta);

        [SerializeField] private T _value;

        // Not serialized — used to detect inspector edits at runtime
        private T _previousValue;
        private bool _initialized;

        /// <summary>
        /// Fired when the value changes.
        /// </summary>
        public event ValueChangedDelegate OnChanged;

        /// <summary>
        /// Gets or sets the value. Fires <see cref="OnChanged"/> only if the value actually changed.
        /// </summary>
        public T Value
        {
            get => _value;
            set
            {
                if (_value != null && _value.Equals(value))
                    return;

                Fire(_value, value);
            }
        }

        /// <summary>
        /// Sets the value and fires events regardless of whether it changed.
        /// </summary>
        public void ForceSet(T value) => Fire(_value, value);

        /// <summary>
        /// Silently updates the value without firing any events.
        /// </summary>
        public void SetSilent(T value) => _value = _previousValue = value;

        private void Fire(T old, T current)
        {
            _value = _previousValue = current;

            T delta;
            try { delta = (T)Convert.ChangeType(Convert.ToDouble(current) - Convert.ToDouble(old), typeof(T)); }
            catch { delta = default; }

            OnChanged?.Invoke(old, current, delta);
        }

        // Called by Unity after the inspector writes to _value
        public void OnAfterDeserialize()
        {
            if (!_initialized)
            {
                _previousValue = _value;
                _initialized = true;
                return;
            }

            if (_value != null && _value.Equals(_previousValue))
                return;

            // Inspector changed the value — fire through the normal path
            var old = _previousValue;
            var current = _value;
            _previousValue = current;

            T delta;
            try { delta = (T)Convert.ChangeType(Convert.ToDouble(current) - Convert.ToDouble(old), typeof(T)); }
            catch { delta = default; }

            OnChanged?.Invoke(old, current, delta);
        }

        public void OnBeforeSerialize() { }

        public Observable(T initialValue = default)
        {
            _value = initialValue;
            _previousValue = initialValue;
            _initialized = true;
        }

        public static implicit operator T(Observable<T> observable) => observable._value;

        public override string ToString() => _value?.ToString();
    }
}