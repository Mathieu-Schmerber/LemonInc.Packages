using System;

namespace LemonInc.Core.Pooling.Exceptions
{
	/// <summary>
	/// Thrown when a pool related exception occurs.
	/// </summary>
	/// <seealso cref="System.Exception" />
	public class PoolException : Exception
	{
		public PoolException(string message) : base(message) { }
	}
}