using LemonInc.Core.StateMachine;
using LemonInc.Core.StateMachine.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Gameplay.Controller.Core
{
    /// <summary>
    /// BaseController with ScriptableObject configuration.
    /// </summary>
    public abstract class BaseController<TConfig> : BaseController
        where TConfig : ControllerConfig
    {
        [SerializeField, InlineEditor] protected TConfig Config;
    }
    
    /// <summary>
    /// Core base for all character controllers.
    /// Owns the state machine and action registry.
    /// Subclass BaseController&lt;TConfig&gt; for ScriptableObject-based configuration.
    /// </summary>
    public abstract class BaseController : MonoBehaviour
    {
        private readonly StateMachine _stateMachine = new();
 
        public IState CurrentState => _stateMachine.CurrentState;
        public IStateMachine StateMachine => _stateMachine;
        public ActionRegistry Actions { get; } = new();

        protected virtual void Awake()
        {
            SetupStates();
            SetupActions();
            OnInitialize();
        }
 
        /// <summary>Register states and sub-state machines, define top-level transitions.</summary>
        protected abstract void SetupStates();
 
        /// <summary>Register actions via RegisterAction&lt;T&gt;().</summary>
        protected abstract void SetupActions();
 
        /// <summary>Called after setup. Set initial active state and any post-setup logic here.</summary>
        protected abstract void OnInitialize();
 
        /// <summary>Creates, binds, and registers a leaf state.</summary>
        protected void RegisterState<T>() where T : BaseControllerState, new()
        {
            var state = new T();
            state.Bind(this);
            _stateMachine.RegisterState(state);
        }
 
        /// <summary>
        /// Creates, binds, and registers a sub-state machine.
        /// OnBind() on the sub-state machine is where it registers its own child states.
        /// </summary>
        protected T RegisterSubStateMachine<T>() where T : BaseControllerSubStateMachine, new()
        {
            var sub = new T();
            sub.Bind(this);
            _stateMachine.RegisterSubStateMachine(sub);
            return sub;
        }
 
        /// <summary>Creates, binds, and registers an action.</summary>
        protected void RegisterAction<T>() where T : BaseControllerAction, new()
        {
            var action = new T();
            action.Bind(this);
            Actions.Register(action);
        }
 
        protected virtual void Update()
        {
            _stateMachine.Update();
            Actions.Update();
        }
 
        protected virtual void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
            Actions.FixedUpdate();
        }
    }
}