using LemonInc.Core.StateMachine.Scriptables;
using UnityEngine;

namespace LemonInc.Core.StateMachine._Samples.SimpleController
{
	internal class ColorAction : ScriptableAction
	{
		[SerializeField] private Color _color;

		/// <inheritdoc/>
		public override void OnEnteredState(StateComponent stateComponent) { }

		/// <inheritdoc/>
		public override void Act(StateComponent stateComponent)
		{
			var colorable = stateComponent.GetComponent<IColorable>();

			colorable?.ChangeColor(_color);
		}
	}
}
