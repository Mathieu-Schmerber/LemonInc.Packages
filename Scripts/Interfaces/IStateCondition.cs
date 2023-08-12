namespace LemonInc.Core.StateMachine.Interfaces
{
	/// <summary>
	/// Describes a state condition.
	/// </summary>
	public interface IStateCondition
	{
		/// <summary>
		/// Called when [entered state].
		/// This method can be used to reset internal values.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		void OnEnteredState(StateComponent stateComponent);

		/// <summary>
		/// Verifies the condition for the specified state component.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		/// <returns></returns>
		bool Verify(StateComponent stateComponent);
	}
}