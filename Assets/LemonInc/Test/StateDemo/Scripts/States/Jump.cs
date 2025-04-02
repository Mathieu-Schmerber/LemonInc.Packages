using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class Jump : StateBase
    {
        public Jump(Transform owner) : base(owner) { }
        public override void OnEnter() => SetColor(Color.cyan);
    }
}