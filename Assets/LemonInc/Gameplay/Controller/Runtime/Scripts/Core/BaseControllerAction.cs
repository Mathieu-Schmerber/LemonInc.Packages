namespace LemonInc.Gameplay.Controller.Core
{
    /// <summary>
    /// Base class for all controller actions.
    /// Actions are spontaneous and triggered: Jump, Dash, Attack, etc.
    /// An action defines what the controller spontaneously DOES.
    /// Whether it is permitted is determined by the active state, not the action itself.
    /// </summary>
    public abstract class BaseControllerAction
    {
        public bool IsEnabled { get; set; } = true;
        public BaseController Controller { get; private set; }

        internal void Bind(BaseController controller)
        {
            Controller = controller;
            OnBind();
        }

        /// <summary>Called once when the action is bound to its controller. Use instead of a constructor.</summary>
        protected virtual void OnBind() { }

        /// <summary>
        /// Returns true if this action can currently fire.
        /// Checks IsEnabled, then defers permission to the active state via IActionGate.
        /// Override to add extra conditions (cooldown, resource check, etc.) — call base first.
        /// </summary>
        public virtual bool CanExecute()
        {
            if (!IsEnabled) return false;
            var gate = Controller.CurrentState as IActionGate;
            return gate == null || gate.AllowsAction(GetType());
        }

        /// <summary>The action logic. Only called when CanExecute() is true.</summary>
        public abstract void Execute();

        /// <summary>Optional per-frame logic (e.g., active dash movement). Only ticked while IsEnabled.</summary>
        public virtual void Update() { }

        /// <summary>Optional per-physics-frame logic. Only ticked while IsEnabled.</summary>
        public virtual void FixedUpdate() { }
    }
}