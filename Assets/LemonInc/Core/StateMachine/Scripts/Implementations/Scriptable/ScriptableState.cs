using LemonInc.Core.StateMachine.Interfaces;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Implementations.Scriptable
{
    public abstract class ScriptableState : ScriptableObject, IState
    {
        public virtual void OnEnter()
        {
            // noop
        }

        public virtual void Update()
        {
            // noop
        }

        public virtual void FixedUpdate()
        {
            // noop
        }

        public virtual void OnExit()
        {
            // noop
        }
    }
}