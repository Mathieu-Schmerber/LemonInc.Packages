using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Scriptables
{
	/// <summary>
	/// Implementation of <see cref="IStateTransition"/> for <see cref="ScriptableState"/>.
	/// </summary>
	/// <seealso cref="LemonInc.Core.StateMachine.Interfaces.IStateTransition" />
	[System.Serializable]
    public class StateTransition : IStateTransition
	{
		[SerializeField] private List<ScriptableCondition> _conditions;
		[SerializeField] private ScriptableState _successState;

		/// <inheritdoc/>
		public IEnumerable<IStateCondition> Conditions
		{
			get => _conditions;
			set => _conditions = value.Cast<ScriptableCondition>().ToList();
		}
		
		/// <inheritdoc/>
		public IState SuccessState
		{
			get => _successState;
			set => _successState = value as ScriptableState;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StateTransition"/> class.
		/// </summary>
		/// <param name="state">The state.</param>
		public StateTransition(ScriptableState state)
		{
			_conditions = new List<ScriptableCondition>();
			_successState = state;
		}

		/// <inheritdoc/>
		public void AddCondition(IStateCondition condition)
		{
			if (condition is ScriptableCondition scriptableCondition)
				_conditions.Add(scriptableCondition);
		}

		/// <inheritdoc/>
		public void RemoveCondition(IStateCondition condition) => _conditions.Remove(condition as ScriptableCondition);
	}
}