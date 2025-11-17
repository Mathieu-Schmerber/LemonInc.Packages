using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LemonInc.Core.Input
{
    /// <summary>
    /// Input provider base with automatic input discovery and update management.
    /// </summary>
    public abstract class InputProviderBase<T> : MonoBehaviour
        where T : IInputActionCollection, new()
    {
        /// <summary>
        /// Control types.
        /// </summary>
        public enum ControlType
        {
            XBOX,
            PS4,
            KEYBOARD
        }

        /// <summary>
        /// Gets the type of the in use control.
        /// </summary>
        public ControlType InUseControlType { get; private set; }
        
        /// <summary>
        /// The player input.
        /// </summary>
        protected PlayerInput _playerInput;
        
        /// <summary>
        /// Occurs when controls changed event.
        /// </summary>
        public event Action<ControlType> OnControlsChangedEvent;

        /// <summary>
        /// The controls asset.
        /// </summary>
        private T _controls;

        /// <summary>
        /// Collection of all updatable inputs for automatic updating.
        /// </summary>
        private List<IUpdatableInput> _updatableInputs;

        /// <summary>
        /// Collection of all discovered input objects for auto-unsubscribe.
        /// </summary>
        private List<object> _allInputs;

        /// <summary>
        /// The controls asset.
        /// </summary>
        public T Controls => _controls ??= new T();

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        protected virtual void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            DiscoverAndRegisterInputs();
        }

        /// <summary>
        /// Automatically discovers and registers all input fields marked with [Input] attribute.
        /// </summary>
        private void DiscoverAndRegisterInputs()
        {
            _updatableInputs = new List<IUpdatableInput>();
            _allInputs = new List<object>();

            var flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var fields = GetType().GetFields(flags);

            foreach (var field in fields)
            {
                // Check if field has [Input] attribute
                if (field.GetCustomAttribute<InputAttribute>() != null)
                {
                    var value = field.GetValue(this);
                    if (value != null)
                    {
                        _allInputs.Add(value);
                        
                        if (value is IUpdatableInput updatableInput)
                        {
                            _updatableInputs.Add(updatableInput);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Automatically unsubscribes all discovered inputs.
        /// </summary>
        private void AutoUnsubscribeInputs()
        {
            if (_allInputs == null)
                return;

            foreach (var input in _allInputs)
            {
                // Try to call UnSubscribe method if it exists
                var unsubscribeMethod = input.GetType().GetMethod("UnSubscribe", BindingFlags.Instance | BindingFlags.Public);
                if (unsubscribeMethod != null && unsubscribeMethod.GetParameters().Length == 0)
                {
                    unsubscribeMethod.Invoke(input, null);
                }
            }
        }

        /// <summary>
        /// Called when enabled.
        /// </summary>
        protected virtual void OnEnable()
        {
            if (_playerInput != null)
                _playerInput.onControlsChanged += OnControlsChanged;

            Controls.Enable();
            SubscribeInputs();
        }

        /// <summary>
        /// Called when disabled.
        /// </summary>
        protected virtual void OnDisable()
        {
            if (_playerInput != null)
                _playerInput.onControlsChanged -= OnControlsChanged;

            Controls.Disable();
            AutoUnsubscribeInputs();
        }

        /// <summary>
        /// Updates all registered inputs every frame.
        /// </summary>
        protected virtual void Update()
        {
            if (_updatableInputs == null)
                return;

            for (int i = 0; i < _updatableInputs.Count; i++)
            {
                _updatableInputs[i]?.Update();
            }
        }

        /// <summary>
        /// Subscribe to input actions. Override if you need custom subscription logic.
        /// </summary>
        protected virtual void SubscribeInputs() { }
        
        /// <summary>
        /// Unsubscribe from input actions. Override if you need custom cleanup logic.
        /// Note: All [Input] marked fields are automatically unsubscribed.
        /// </summary>
        protected virtual void UnSubscribeInputs() { }

        /// <summary>
        /// Called when controls changed.
        /// </summary>
        private void OnControlsChanged(PlayerInput input)
        {
            if (!input.devices.Any())
                return;

            if (input.devices[0].device.displayName.Contains("Keyboard"))
                InUseControlType = ControlType.KEYBOARD;
            else if (Gamepad.current is UnityEngine.InputSystem.XInput.XInputController)
                InUseControlType = ControlType.XBOX;
            else if (Gamepad.current is UnityEngine.InputSystem.DualShock.DualShockGamepad)
                InUseControlType = ControlType.PS4;
                
            OnControlsChangedEvent?.Invoke(InUseControlType);
        }
    }
}