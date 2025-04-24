using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class Idle : StateBase
    {
        public Idle(Transform owner) : base(owner) {}
        public override void OnEnter() => SetColor(Color.white);
    }
}