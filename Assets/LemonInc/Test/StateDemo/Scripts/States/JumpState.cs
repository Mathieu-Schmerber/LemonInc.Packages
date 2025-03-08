using LemonInc.Core.StateMachine.Scripts;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class JumpState : StateBase
    {
        private readonly Controller _controller;

        public JumpState(Controller controller)
        {
            _controller = controller;
        }
        
        public override void FixedUpdate()
        {
            _controller.HandleMovements();
        }
    }
}