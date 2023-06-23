namespace LemonInc.Core.Pooling
{
    /// <summary>
    /// Describes a Pool.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPool<T>
		where T : IPoolable
    {
        
    }
}
