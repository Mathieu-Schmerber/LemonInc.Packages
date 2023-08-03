namespace LemonInc.Core.Input
{
	/// <summary>
	/// Input provider.
	/// </summary>
	/// <typeparam name="T">Input class.</typeparam>
	public interface IInputProvider
    {
	    /// <summary>
        /// Processes the inputs.
        /// </summary>
	    void ProcessInputs();
    }
}