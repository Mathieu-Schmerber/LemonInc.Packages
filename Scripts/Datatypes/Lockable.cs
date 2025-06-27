using System;
using UnityEngine;

namespace LemonInc.Core.Utilities.Datatypes
{
    [Serializable]
    public abstract class LockableBase
    {
        [SerializeField] private bool _locked;
        public bool Locked => _locked;
        public void Lock() => _locked = true;
        public void Unlock() => _locked = false;
        public void ToggleLock() => _locked = !_locked;

        public void TriggerValuedChanged() => OnTriggerValueChanged();
        internal virtual void OnTriggerValueChanged() {}
    }

    [Serializable]
    public class Lockable<T> : LockableBase
    {
        [SerializeField] private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (!Locked && !Equals(_value, value))
                {
                    _value = value;
                    OnValueChanged?.Invoke(_value);
                }
            }
        }

        public event Action<T> OnValueChanged;

        public void LockTo(T value)
        {
            _value = value;
            Lock();
            OnValueChanged?.Invoke(_value);
        }

        public static implicit operator T(Lockable<T> l) => l.Value;

        public Lockable(T value)
        {
            _value = value;
            Unlock();
        }

        internal override void OnTriggerValueChanged() => OnValueChanged?.Invoke(_value);
    }
}