namespace LemonInc.Core.StateMachine.Interfaces
{
    /// <summary>
    /// Defines a finite state machine state.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Called when entering the state.
        /// </summary>
        void OnEnter();

        /// <summary>
        /// Called every frame, while the state is active.
        /// </summary>
        void Update();

        /// <summary>
        /// Called every physics frame, while the state is active.
        /// </summary>
        void FixedUpdate();

        /// <summary>
        /// Called when exiting the state.
        /// </summary>
        void OnExit();
    }
}