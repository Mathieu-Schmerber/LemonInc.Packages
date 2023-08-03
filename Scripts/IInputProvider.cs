namespace LemonInc.Core.Input
{
    /// <summary>
    /// Input provider.
    /// </summary>
    /// <typeparam name="T">Input class.</typeparam>
    public interface IInputProvider
    {
	    /// <summary>
	    /// Gets the input state.
	    /// </summary>
	    /// <param name="state">Initial state.</param>
	    /// <returns>The state.</returns>
	    object GetInput(object state);
    }
}