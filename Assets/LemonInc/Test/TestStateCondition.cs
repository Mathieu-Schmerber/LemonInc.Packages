using LemonInc.Core.StateMachine;
using LemonInc.Core.StateMachine.Scriptables;
using Sirenix.Serialization;

namespace LemonInc.Test
{
    public class TestStateCondition : ScriptableCondition
    {
        public delegate bool Check();
        
        [OdinSerialize] public Check CheckDelegate;
        
        public override bool Verify(StateComponent statesComponent)
        {
            return true;
        }
    }
}