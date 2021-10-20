#nullable enable

using System.Collections.Generic;

namespace ProjectCard.Shared.CollectionModule
{
    public interface IReadonlyDeck<T>
    {
        T Top { get; }
        T Bottom { get; }
        int Count { get; }
        bool IsEmpty { get; }
    }
    public interface IDeck<T> : IReadonlyDeck<T>
    {
        bool TryPop(out T data);
        void Shuffle(int times);
        void Shuffle(int from, int times);
        void Reset();
    }
    public class Deck<T> : IDeck<T>
    {
        private readonly IReadOnlyList<T> datas;
        private readonly DecrementalIndexes indexes;

        public int Count => indexes.Count;
        public bool IsEmpty => indexes.IsEmpty;

        public T Top => datas[indexes.Peek()];
        public T Bottom => datas[indexes.PeekFirst()];


        public Deck(IReadOnlyList<T> datas)
        {
            this.datas = datas;

            indexes = new DecrementalIndexes(datas.Count);
        }


        public bool TryPop(out T data)
        {
            if (IsEmpty)
            {
                data = default!;
                return false;
            }

            var index = indexes.Next();

            data = datas[index];

            return true;
        }

        public void Shuffle(int times = 1) => indexes.Randomize(times);
        public void Shuffle(int from, int times = 1) => indexes.Randomize(from, times);

        public void Reset() => indexes.ResetIndex();
    }
}