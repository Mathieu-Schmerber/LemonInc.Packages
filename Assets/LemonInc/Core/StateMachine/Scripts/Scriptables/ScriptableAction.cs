using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Scriptables
{
	/// <summary>
	/// Implementation of <see cref="IStateAction"/> for <see cref="ScriptableObject"/>.
	/// </summary>
	/// <seealso cref="UnityEngine.ScriptableObject" />
	/// <seealso cref="LemonInc.Core.StateMachine.Interfaces.IStateAction" />
	public abstract class ScriptableAction : ScriptableObject, IStateAction
	{
		/// <inheritdoc/>
		public abstract void OnEnteredState(StateComponent stateComponent);

		/// <inheritdoc/>
		public abstract void Act(StateComponent stateComponent);
    }
}