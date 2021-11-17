#nullable enable


namespace ProjectCard.Shared.CollectionModule
{
    public interface IStorage<TKey> : IReadonlyStorage<TKey>
    {
        void Store(TKey key, object data);

        T? Restore<T>(TKey key);

        T RestoreOrCreate<T>(TKey key) where T : new();

        void Clear();
    }
}