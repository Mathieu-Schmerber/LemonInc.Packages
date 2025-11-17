namespace LemonInc.Core.Input
{
    /// <summary>
    /// Describes an input.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InputStateValue<T> : InputState
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public virtual T Value { get; protected set; }

        /// <summary>
        /// Occurs when [on value changed].
        /// </summary>
        public event ValueChanged OnValueChanged;

        /// <summary>
        /// Value changed delegate.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="currentValue">The current value.</param>
        public delegate void ValueChanged(T oldValue, T currentValue);

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public void SetValue(T newValue)
        {
            var old = Value;

            if (!old.Equals(newValue))
            {
                Value = newValue;
                OnValueChanged?.Invoke(old, Value);
            }
        }
    }
}