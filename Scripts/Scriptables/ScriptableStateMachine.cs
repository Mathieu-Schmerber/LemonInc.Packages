using System.Linq;
using LemonInc.Core.StateMachine.Interfaces;
using LemonInc.Core.Utilities.Extensions;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Scriptables
{
	/// <summary>
	/// Implementation of <see cref="IStateMachine"/> for <see cref="ScriptableObject"/>.
	/// </summary>
	/// <seealso cref="UnityEngine.ScriptableObject" />
	/// <seealso cref="LemonInc.Core.StateMachine.Interfaces.IStateMachine" />
	[CreateAssetMenu(menuName = "Lemon Inc/State Machine", fileName = "State Machine")]
    public class ScriptableStateMachine : ScriptableObject, IStateMachine
    {
        [SerializeField] private ScriptableState _initialState;
		
		/// <inheritdoc/>
		public IState InitialState
		{
			get => _initialState;
			set => _initialState = value as ScriptableState;
		}

		/// <inheritdoc/>
		public IState ProcessTransitions(StateComponent stateComponent, IState currentState)
		{
			if (currentState.Transitions.IsNullOrEmpty())
				return currentState;

			foreach (var stateTransition in currentState.Transitions)
			{
				if (stateTransition.Conditions.IsNullOrEmpty())
					return stateTransition.SuccessState ?? currentState;

				if (stateTransition.Conditions.All(condition => condition.Verify(stateComponent)))
					return stateTransition.SuccessState;
			}

			return currentState;
		}
    }
}
