namespace LemonInc.Core.Input
{
    /// <summary>
    /// Interface for inputs that need per-frame updates.
    /// </summary>
    public interface IUpdatableInput
    {
        void Update();
    }
}