namespace LemonInc.Core.StateMachine.Interfaces
{
	/// <summary>
	/// Describes a state condition.
	/// </summary>
	public interface IStateCondition
	{
		/// <summary>
		/// Called when the state where the condition sits is entered.
		/// Use this method to set some data and subscribe to events.
		/// </summary>
		/// <param name="stateComponent"></param>
		void OnStateEntered(StateComponent stateComponent);

		/// <summary>
		/// Verifies the condition for the specified state component.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		/// <returns></returns>
		bool Verify(StateComponent stateComponent);

		/// <summary>
		/// Called when the state where the condition sits is exited.
		/// Use this method to reset some data and unsubscribe from events.
		/// </summary>
		/// <param name="stateComponent"></param>
		void OnStateExited(StateComponent stateComponent);
	}
}