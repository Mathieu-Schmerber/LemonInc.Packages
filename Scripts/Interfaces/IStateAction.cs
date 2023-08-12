namespace LemonInc.Core.StateMachine.Interfaces
{
	/// <summary>
	/// Describes a state action.
	/// </summary>
	public interface IStateAction
	{
		/// <summary>
		/// Called when [entered state].
		/// This method can be used to reset internal values.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		void OnEnteredState(StateComponent stateComponent);

		/// <summary>
		/// Acts with the specified state component.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		void Act(StateComponent stateComponent);
	}
}
