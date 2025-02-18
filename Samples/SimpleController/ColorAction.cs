using LemonInc.Core.StateMachine.Scriptables;
using UnityEngine;

namespace LemonInc.Core.StateMachine._Samples.SimpleController
{
	public class ColorAction : ScriptableAction
	{
		[SerializeField] private Color _color;
		
		/// <inheritdoc/>
		public override void Act(StateComponent stateComponent)
		{
			var colorable = stateComponent.GetComponent<IColorable>();

			colorable?.ChangeColor(_color);
		}
	}
}
