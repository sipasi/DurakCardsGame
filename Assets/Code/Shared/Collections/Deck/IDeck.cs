


namespace ProjectCard.Shared.Collections
{
    public interface IDeck<T> : IReadonlyDeck<T>
    {
        bool TryPop(out T data);
        void Shuffle(int times);
        void Shuffle(int from, int times);
        void Clear();
    }
}