namespace LemonInc.Core.StateMachine.Interfaces
{
    /// <summary>
    /// Defines a predicate.
    /// </summary>
    public interface IPredicate
    {
        /// <summary>
        /// Evaluates the predicate.
        /// </summary>
        bool Evaluate();
    }
}
