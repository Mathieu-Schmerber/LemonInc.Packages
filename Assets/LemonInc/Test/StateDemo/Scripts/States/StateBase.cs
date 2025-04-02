using LemonInc.Core.StateMachine.FSM;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public abstract class StateBase : State
    {
        private readonly Renderer _renderer;
        protected Transform Owner { get; set; }

        protected StateBase(Transform owner)
        {
            Owner = owner;
            _renderer = owner.gameObject.GetComponent<Renderer>();
        }

        protected void SetColor(Color color)
        {
            _renderer.material.color = color;
        }
    }
}