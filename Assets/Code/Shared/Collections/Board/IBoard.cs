namespace Framework.Shared.Collections
{
    public interface IBoard<T> : IReadonlyBoard<T>
    {
        void Add(T item);
        void AddToAttacks(T item);
        void AddToDefends(T item);

        void Clear();
    }
}
