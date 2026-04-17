using System;
using System.Collections.Generic;

namespace LemonInc.Gameplay.Controller.Core
{
    /// <summary>
    /// Manages all actions registered on a controller.
    /// Handles enabling/disabling and execution gating.
    /// </summary>
    public class ActionRegistry
    {
        private readonly Dictionary<Type, BaseControllerAction> _actions = new();
 
        public void Register(BaseControllerAction action)
            => _actions[action.GetType()] = action;
 
        public T Get<T>() where T : BaseControllerAction
            => _actions.GetValueOrDefault(typeof(T)) as T;
 
        /// <summary>Attempts to execute an action. Returns false if not found or CanExecute() fails.</summary>
        public bool TryExecute<T>() where T : BaseControllerAction
        {
            var action = Get<T>();
            if (action == null || !action.CanExecute()) return false;
            action.Execute();
            return true;
        }
 
        public void Enable<T>() where T : BaseControllerAction
        {
            var action = Get<T>();
            if (action != null) action.IsEnabled = true;
        }
 
        public void Disable<T>() where T : BaseControllerAction
        {
            var action = Get<T>();
            if (action != null) action.IsEnabled = false;
        }
 
        public void SetEnabled<T>(bool enabled) where T : BaseControllerAction
        {
            var action = Get<T>();
            if (action != null) action.IsEnabled = enabled;
        }
 
        public void Update()
        {
            foreach (var action in _actions.Values)
                if (action.IsEnabled) action.Update();
        }
 
        public void FixedUpdate()
        {
            foreach (var action in _actions.Values)
                if (action.IsEnabled) action.FixedUpdate();
        }
    }
}