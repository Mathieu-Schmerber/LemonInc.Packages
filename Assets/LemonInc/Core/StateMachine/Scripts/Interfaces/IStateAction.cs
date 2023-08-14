namespace LemonInc.Core.StateMachine.Interfaces
{
	/// <summary>
	/// Describes a state action.
	/// </summary>
	public interface IStateAction
	{
		/// <summary>
		/// Acts with the specified state component.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		void Act(StateComponent stateComponent);
	}
}
