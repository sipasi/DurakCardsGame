namespace Framework.Shared.Collections
{
    public interface IIndexer<TKey, TValue> : IReadonlyIndexer<TKey, TValue>
    {
        new TValue this[TKey index] { get; set; }
    }
}