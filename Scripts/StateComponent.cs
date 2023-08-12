using LemonInc.Core.StateMachine.Interfaces;
using LemonInc.Core.StateMachine.Scriptables;
using UnityEngine;

namespace LemonInc.Core.StateMachine
{
	/// <summary>
	/// State component.
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class StateComponent : MonoBehaviour
    {
        [SerializeField] private ScriptableStateMachine _stateMachine;

        private IState _currentState;
        public IState CurrentState => _currentState;

		/// <summary>
		/// State change delegate.
		/// </summary>
		/// <param name="previousState">State of the previous.</param>
		/// <param name="currentState">State of the current.</param>
		public delegate void StateChangeDelegate(IState previousState, IState currentState);

		/// <summary>
		/// Occurs when [on state changed].
		/// </summary>
		public event StateChangeDelegate OnStateChanged;

		/// <summary>
		/// Starts this instance.
		/// </summary>
		private void Start()
        {
            if (_stateMachine.InitialState == null)
            {
                Debug.LogError($"<b><color=white>{_stateMachine.name}</color></b> has no initial state attached to it, the state machine can't be initialized.", this);
                return;
            }

            _currentState = _stateMachine.InitialState;
            _currentState.Begin(this);
        }

		/// <summary>
		/// Physics update.
		/// </summary>
		private void FixedUpdate()
        {
	        _currentState?.UpdatePhysics(this);
        }

		/// <summary>
		/// Updates this instance.
		/// </summary>
		private void Update()
        {
	        _currentState?.UpdateState(this);
        }

		/// <summary>
		/// Late update.
		/// </summary>
		private void LateUpdate()
        {
            if (_currentState == default)
                return;
            
            ProcessTransition();
        }

		/// <summary>
		/// Processes the transition.
		/// </summary>
		private void ProcessTransition()
        {
            var nextState = _stateMachine.ProcessTransitions(this, _currentState);
            if (nextState.Id.Equals(_currentState.Id)) 
	            return;

            var previousState = CurrentState;
            _currentState.End(this);
            _currentState = nextState;
            _currentState.Begin(this);

            OnStateChanged?.Invoke(previousState,nextState);
        }
    }
}