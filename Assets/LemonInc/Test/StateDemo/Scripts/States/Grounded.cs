using LemonInc.Core.StateMachine;

namespace LemonInc.Test.StateDemo.Scripts.States
{
    public class Grounded : SubStateMachine
    {
        private readonly Controller _controller;

        public Grounded(Controller controller)
        {
            _controller = controller;
        }

        protected override void OnUpdate() => _controller.HandleJump();
    }
}