namespace Framework.Shared.Collections
{
    public interface IMap<T1, T2>
    {
        IReadonlyIndexer<T1, T2> Forward { get; }
        IReadonlyIndexer<T2, T1> Reverse { get; }
    }
}