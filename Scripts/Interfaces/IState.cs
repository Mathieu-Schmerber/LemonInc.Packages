using System.Collections.Generic;

namespace LemonInc.Core.StateMachine.Interfaces
{
	/// <summary>
	/// Describes a state.
	/// </summary>
	public interface IState
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public string Id { get; }

		/// <summary>
		/// Gets or sets the alias.
		/// </summary>
		/// <value>
		/// The alias.
		/// </value>
		public string Alias { get; }

		/// <summary>
		/// Gets the transitions.
		/// </summary>
		/// <value>
		/// The transitions.
		/// </value>
		IReadOnlyList<IStateTransition> Transitions { get; }

		/// <summary>
		/// Gets the entry actions.
		/// </summary>
		/// <value>
		/// The entry actions.
		/// </value>
		IReadOnlyList<IStateAction> EntryActions { get; }

		/// <summary>
		/// Gets the exit actions.
		/// </summary>
		/// <value>
		/// The exit actions.
		/// </value>
		IReadOnlyList<IStateAction> ExitActions { get; }

		/// <summary>
		/// Gets the physics actions.
		/// </summary>
		/// <value>
		/// The physics actions.
		/// </value>
		IReadOnlyList<IStateAction> PhysicsActions { get; }

		/// <summary>
		/// Gets the state actions.
		/// </summary>
		/// <value>
		/// The state actions.
		/// </value>
		IReadOnlyList<IStateAction> StateActions { get; }

		/// <summary>
		/// Begins the state.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		void Begin(StateComponent stateComponent);

		/// <summary>
		/// Ends the state.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		void End(StateComponent stateComponent);

		/// <summary>
		/// Updates the state.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		void UpdateState(StateComponent stateComponent);

		/// <summary>
		/// Updates the physics.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		void UpdatePhysics(StateComponent stateComponent);

		/// <summary>
		/// Adds the transition.
		/// </summary>
		/// <param name="transition">The transition.</param>
		void AddTransition(IStateTransition transition);

		/// <summary>
		/// Removes the transition.
		/// </summary>
		/// <param name="transition">The transition.</param>
		void RemoveTransition(IStateTransition transition);

		/// <summary>
		/// Adds the entry action.
		/// </summary>
		/// <param name="action">The action.</param>
		void AddEntryAction(IStateAction action);

		/// <summary>
		/// Removes the entry action.
		/// </summary>
		/// <param name="action">The action.</param>
		void RemoveEntryAction(IStateAction action);

		/// <summary>
		/// Adds the exit action.
		/// </summary>
		/// <param name="action">The action.</param>
		void AddExitAction(IStateAction action);

		/// <summary>
		/// Removes the exit action.
		/// </summary>
		/// <param name="action">The action.</param>
		void RemoveExitAction(IStateAction action);

		/// <summary>
		/// Adds the physics action.
		/// </summary>
		/// <param name="action">The action.</param>
		void AddPhysicsAction(IStateAction action);

		/// <summary>
		/// Removes the physics action.
		/// </summary>
		/// <param name="action">The action.</param>
		void RemovePhysicsAction(IStateAction action);

		/// <summary>
		/// Adds the state action.
		/// </summary>
		/// <param name="action">The action.</param>
		void AddStateAction(IStateAction action);

		/// <summary>
		/// Removes the state action.
		/// </summary>
		/// <param name="action">The action.</param>
		void RemoveStateAction(IStateAction action);
	}
}