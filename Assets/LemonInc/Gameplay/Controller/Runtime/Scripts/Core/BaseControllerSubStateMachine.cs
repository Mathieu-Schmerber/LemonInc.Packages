using System;
using LemonInc.Core.StateMachine;

namespace LemonInc.Gameplay.Controller.Core
{
    /// <summary>
    /// Base class for sub-state machines used as controller states.
    /// Mirrors BaseControllerState's Bind / OnBind / AllowedActions pattern,
    /// but extends SubStateMachine instead of State.
    /// Child states are registered here in OnBind() via RegisterBoundState&lt;T&gt;().
    /// </summary>
    public abstract class BaseControllerSubStateMachine : SubStateMachine, IActionGate
    {
        public BaseController Controller { get; private set; }
 
        internal void Bind(BaseController controller)
        {
            Controller = controller;
            OnBind();
        }
 
        /// <summary>
        /// Called once after binding. Register child states and define transitions here
        /// instead of in a constructor.
        /// </summary>
        protected virtual void OnBind() { }
 
        /// <summary>
        /// Action types permitted while this sub-state machine is the active top-level state.
        /// Return null to allow all actions (default). Return empty to forbid all.
        /// </summary>
        protected virtual Type[] AllowedActions => null;
 
        public bool AllowsAction(Type actionType)
        {
            if (AllowedActions == null) return true;
            return Array.IndexOf(AllowedActions, actionType) >= 0;
        }
 
        /// <summary>
        /// Creates, binds to the root controller, and registers a child state.
        /// Use this instead of RegisterState&lt;T&gt;() for BaseControllerState children.
        /// </summary>
        protected void RegisterBoundState<T>() where T : BaseControllerState, new()
        {
            var state = new T();
            state.Bind(Controller);
            RegisterState(state);
        }
    }
}