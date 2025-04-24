using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class Run : StateBase
    {
        public Run(Transform owner) : base(owner) { }
        public override void OnEnter() => SetColor(Color.red);

        public override void FixedUpdate()
        {
            Controller.HandleMovements();
        }
    }
}