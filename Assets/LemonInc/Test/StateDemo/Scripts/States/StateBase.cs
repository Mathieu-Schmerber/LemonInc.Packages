using LemonInc.Core.StateMachine;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public abstract class StateBase : State
    {
        private readonly Renderer _renderer;
        protected Transform Owner;
        protected Controller Controller;

        protected StateBase(Transform owner)
        {
            Owner = owner;
            Controller = owner.GetComponent<Controller>();
            _renderer = owner.gameObject.GetComponent<Renderer>();
        }

        protected void SetColor(Color color)
        {
            _renderer.material.color = color;
        }
    }
}