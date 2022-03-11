using System.Collections.Generic;

namespace Framework.Shared.Collections
{
    public interface IReadonlyIndexer<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        int Count { get; }

        TValue this[TKey index] { get; }
    }
}