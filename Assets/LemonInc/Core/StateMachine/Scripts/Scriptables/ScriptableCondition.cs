using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Scriptables
{
	/// <summary>
	/// Implementation of <see cref="IStateCondition"/> for <see cref="ScriptableObject"/>.
	/// </summary>
	/// <seealso cref="UnityEngine.ScriptableObject" />
	/// <seealso cref="LemonInc.Core.StateMachine.Interfaces.IStateCondition" />
	public abstract class ScriptableCondition : ScriptableObject, IStateCondition
    {
	    /// <inheritdoc/>
	    public virtual void OnStateEntered(StateComponent stateComponent) {}

		/// <inheritdoc/>
		public abstract bool Verify(StateComponent statesComponent);

		/// <inheritdoc/>
		public virtual void OnStateExited(StateComponent stateComponent) { }
	}
}