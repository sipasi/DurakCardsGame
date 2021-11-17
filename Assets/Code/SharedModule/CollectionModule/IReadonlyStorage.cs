#nullable enable


namespace ProjectCard.Shared.CollectionModule
{
    public interface IReadonlyStorage<TKey>
    {
        public int Count { get; }

        bool Contains(TKey key);
    }
}
