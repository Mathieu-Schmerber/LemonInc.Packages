using LemonInc.Core.StateMachine.Scriptables;
using UnityEngine;

namespace LemonInc.Core.StateMachine._Samples.SimpleController
{
	public class TimeCondition : ScriptableCondition
	{
		[SerializeField] private float _duration;
		private float _lastTick;
		
		public override void OnStateEntered(StateComponent stateComponent)
		{
			_lastTick = Time.time;
		}

		/// <inheritdoc/>
		public override bool Verify(StateComponent statesComponent)
		{
			if (Time.time >= _lastTick + _duration)
			{
				_lastTick = Time.time;
				return true;
			}

			return false;
		}
	}
}