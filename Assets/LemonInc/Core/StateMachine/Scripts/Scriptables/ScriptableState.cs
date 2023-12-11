using System;
using System.Collections.Generic;
using LemonInc.Core.StateMachine.Interfaces;
using LemonInc.Core.Utilities.Graph;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Scriptables
{
	/// <summary>
	/// Implementation of <see cref="IState"/> for <see cref="ScriptableObject"/>.
	/// </summary>
	/// <seealso cref="UnityEngine.ScriptableObject" />
	/// <seealso cref="LemonInc.Core.StateMachine.Interfaces.IState" />
    public class ScriptableState : ScriptableObject, IState, INode, ICloneable
	{
		[SerializeField] private List<ScriptableAction> _entryActions = new();
		[SerializeField] private List<ScriptableAction> _exitActions = new();
		[SerializeField] private List<ScriptableAction> _updateActions = new();
		[SerializeField] private List<ScriptableAction> _physicsActions = new();
		[SerializeField] private Vector2 _nodePosition;
		[SerializeField] private string _guid;
		[SerializeField] private string _title = "New State";
		[SerializeField] private List<StateTransition> _transitions = new();

		public string Id => _guid;
		
		/// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>
        /// The alias.
        /// </value>
        public string Alias { get => _title; set => _title = value; }

		/// <summary>
		/// Gets the position in editor graph.
		/// </summary>
		public Vector2 Position { get => _nodePosition; set => _nodePosition = value; }
		
		/// <inheritdoc/>
		public IReadOnlyList<IStateTransition> Transitions => _transitions;

		/// <inheritdoc/>
		public IReadOnlyList<IStateAction> EntryActions => _entryActions;

		/// <inheritdoc/>
		public IReadOnlyList<IStateAction> ExitActions => _exitActions;

		/// <inheritdoc/>
		public IReadOnlyList<IStateAction> PhysicsActions => _physicsActions;

		/// <inheritdoc/>
		public IReadOnlyList<IStateAction> StateActions => _updateActions;

		private void Awake()
		{
			name = Alias;
			_guid ??= Guid.NewGuid().ToString();
		}

		/// <summary>
		/// Executes the actions.
		/// </summary>
		/// <param name="stateComponent">The state component.</param>
		/// <param name="actions">The actions.</param>
		/// <param name="debugIdentifier">The debug identifier.</param>
		private void ExecuteActions(StateComponent stateComponent, IReadOnlyList<IStateAction> actions, string debugIdentifier)
		{
			if (actions == null)
				return;

	        foreach (var stateAction in actions)
	        {
		        if (stateAction == null)
		        {
                    Debug.LogError($"[SCRIPTABLE STATE] {debugIdentifier} list has a null element", this);
                    continue;
		        }

                stateAction.Act(stateComponent);
	        }
        }

		/// <summary>
		/// Adds to list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item">The item.</param>
		/// <param name="destination">The destination.</param>
		private static void AddToList<T>(object item, List<T> destination)
		{
			if (item is T typedItem)
				destination.Add(typedItem);
			else
				Debug.LogError($"[ScriptableState] Unsupported type. Expected '{typeof(T).Name}' but got '{item.GetType().Name}'");
		}

		/// <summary>
		/// Removes from list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item">The item.</param>
		/// <param name="destination">The destination.</param>
		private static void RemoveFromList<T>(object item, List<T> destination)
			where T : class
			=> destination.Remove(item as T);

		/// <inheritdoc/>
		public void Begin(StateComponent stateComponent)
		{
			foreach (var stateTransition in Transitions)
				foreach (var stateTransitionCondition in stateTransition.Conditions)
					stateTransitionCondition.OnStateEntered(stateComponent);

			ExecuteActions(stateComponent, EntryActions, nameof(EntryActions));
		}

		/// <inheritdoc/>
		public void End(StateComponent stateComponent)
		{
			foreach (var stateTransition in Transitions)
				foreach (var stateTransitionCondition in stateTransition.Conditions)
					stateTransitionCondition.OnStateExited(stateComponent);

			ExecuteActions(stateComponent, ExitActions, nameof(ExitActions));
		}

		/// <inheritdoc/>
        public void UpdatePhysics(StateComponent stateComponent)
	        => ExecuteActions(stateComponent, PhysicsActions, nameof(PhysicsActions));

        /// <inheritdoc/>
        public void UpdateState(StateComponent stateComponent)
	        => ExecuteActions(stateComponent, StateActions, nameof(StateActions));

		/// <inheritdoc/>
		public void AddTransition(IStateTransition transition) => AddToList(transition, _transitions);

        /// <inheritdoc/>
        public void RemoveTransition(IStateTransition transition) => RemoveFromList(transition, _transitions);

        /// <inheritdoc/>
		public void AddEntryAction(IStateAction action) => AddToList(action, _entryActions);

        /// <inheritdoc/>
		public void RemoveEntryAction(IStateAction action) => RemoveFromList(action, _entryActions);

        /// <inheritdoc/>
		public void AddExitAction(IStateAction action) => AddToList(action, _exitActions);

		/// <inheritdoc/>
		public void RemoveExitAction(IStateAction action) => RemoveFromList(action, _exitActions);

		/// <inheritdoc/>
		public void AddPhysicsAction(IStateAction action) => AddToList(action, _physicsActions);

		/// <inheritdoc/>
		public void RemovePhysicsAction(IStateAction action) => RemoveFromList(action, _physicsActions);

		/// <inheritdoc/>
		public void AddStateAction(IStateAction action) => AddToList(action, _updateActions);

		/// <inheritdoc/>
		public void RemoveStateAction(IStateAction action) => RemoveFromList(action, _updateActions);

		/// <inheritdoc/>
		public object Clone()
		{
			var clone = ScriptableObject.CreateInstance<ScriptableState>();

			clone.Alias = this.Alias;
			clone.Position = this.Position;
			return clone;
		}
	}
}