using System;
using LemonInc.Core.StateMachine;

namespace LemonInc.Gameplay.Controller.Core
{
    /// <summary>
    /// Base class for all controller states.
    /// States are restrictive and behavior-based: Grounded, Airborne, Running, etc.
    /// A state defines what the controller IS, not what it spontaneously DOES —
    /// and declares which actions are permitted while it is active.
    /// </summary>
    public abstract class BaseControllerState : State
    {
        public BaseController Controller { get; private set; }
 
        internal void Bind(BaseController controller)
        {
            Controller = controller;
            OnBind();
        }
 
        /// <summary>Called once when the state is bound to its controller. Use instead of a constructor.</summary>
        protected virtual void OnBind() { }
 
        /// <summary>
        /// Action types permitted while this state is active.
        /// Return null to allow all registered actions (default).
        /// Return an empty array to forbid all actions.
        /// </summary>
        protected virtual Type[] AllowedActions => null;
 
        /// <summary>Returns whether the given action type may execute in this state.</summary>
        public bool AllowsAction(Type actionType)
        {
            if (AllowedActions == null) return true;
            return Array.IndexOf(AllowedActions, actionType) >= 0;
        }
    }
}