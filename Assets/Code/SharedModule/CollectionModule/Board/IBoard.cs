namespace ProjectCard.Shared.CollectionModule
{
    public interface IBoard<T> : IReadonlyBoard<T>
    {
        void Add(T item);
        void AddToAttacks(T item);
        void AddToDefends(T item);
        bool TryGetLast(out T item);
        void Clear();
    }
}
