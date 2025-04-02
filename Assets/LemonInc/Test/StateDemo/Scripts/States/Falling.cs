using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class Falling : StateBase
    {
        public Falling(Transform owner) : base(owner) { }
        public override void OnEnter() => SetColor(Color.magenta);
    }
}