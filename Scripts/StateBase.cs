using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine
{
    public abstract class StateBase : IState
    {
        protected GameObject Owner { get; private set; }

        protected StateBase(GameObject owner)
        {
            Owner = owner;
        }
        
        public virtual void OnEnter() {}
        public virtual void Update() {}
        public virtual void FixedUpdate() {}
        public virtual void OnExit() {}
    }
}