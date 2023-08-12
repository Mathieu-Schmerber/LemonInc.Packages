namespace LemonInc.Core.StateMachine.Interfaces
{
	/// <summary>
	/// Describes a state machine.
	/// </summary>
	public interface IStateMachine
	{
		/// <summary>
		/// Gets the initial state.
		/// </summary>
		/// <value>
		/// The initial state.
		/// </value>
		IState InitialState { get; set; }

		/// <summary>
		/// Processes the transitions.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		/// <param name="currentState">The current state.</param>
		/// <returns>The state to switch to.</returns>
		IState ProcessTransitions(StateComponent stateComponent, IState currentState);
	}
}