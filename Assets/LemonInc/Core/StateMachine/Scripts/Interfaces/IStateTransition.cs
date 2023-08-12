using System.Collections.Generic;

namespace LemonInc.Core.StateMachine.Interfaces
{
	/// <summary>
	/// Describes a state transition.
	/// </summary>
	public interface IStateTransition
	{
		/// <summary>
		/// Gets the conditions to fulfill to transition.
		/// </summary>
		/// <value>
		/// The conditions.
		/// </value>
		public IEnumerable<IStateCondition> Conditions { get; }

		/// <summary>
		/// Gets the state to transition to if conditions are met.
		/// </summary>
		/// <value>
		/// The state of success.
		/// </value>
		public IState SuccessState { get; set; }

		/// <summary>
		/// Adds a condition.
		/// </summary>
		/// <param name="condition">The condition.</param>
		public void AddCondition(IStateCondition condition);

		/// <summary>
		/// Removes a condition.
		/// </summary>
		/// <param name="condition">The condition.</param>
		public void RemoveCondition(IStateCondition condition);
	}
}
