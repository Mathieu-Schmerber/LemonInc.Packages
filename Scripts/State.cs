using LemonInc.Core.StateMachine.Interfaces;

namespace LemonInc.Core.StateMachine
{
    public abstract class State : IState
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