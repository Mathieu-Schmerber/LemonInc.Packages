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
	    public abstract void OnEnteredState(StateComponent stateComponent);

		/// <inheritdoc/>
		public abstract bool Verify(StateComponent statesComponent);
    }
}