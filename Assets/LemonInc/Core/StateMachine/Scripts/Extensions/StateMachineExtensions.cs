using System;
using LemonInc.Core.StateMachine.Interfaces;

namespace LemonInc.Core.StateMachine.Extensions
{
    /// <summary>
    /// Extensions for the <see cref="StateMachine"/> class.
    /// </summary>
    public static class StateMachineExtensions
    {
        /// <summary>
        /// Adds a transition using a <see cref="FuncPredicate"/>.
        /// </summary>
        /// <param name="stateMachine">The state machine.</param>
        /// <param name="predicate">The predicate.</param>
        /// <typeparam name="TFrom">The state to transition from.</typeparam>
        /// <typeparam name="TTo">The state to transition to.</typeparam>
        public static void AddTransition<TFrom, TTo>(this StateMachine stateMachine, Func<bool> predicate)
            where TFrom : IState
            where TTo : IState
        {
            stateMachine.AddTransition<TFrom, TTo>(new FuncPredicate(predicate));
        }
    }
}