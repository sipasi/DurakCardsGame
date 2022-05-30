
using System;

namespace Framework.Shared.Collections
{
    public interface IStorage<TKey> : IReadonlyStorage<TKey>
    {
        void Store(TKey key, object data);

        T Restore<T>(TKey key);

        T RestoreOrCreate<T>(TKey key) where T : new();
        T RestoreOrCreate<T>(TKey key, Func<T> factory);
        T RestoreOrCreate<T>(TKey key, Func<TKey, T> factory);

        void Clear();
    }
}