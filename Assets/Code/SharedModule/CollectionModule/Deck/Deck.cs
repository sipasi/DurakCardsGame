#nullable enable

using System;
using System.Collections;
using System.Collections.Generic; 

namespace ProjectCard.Shared.CollectionModule
{
    [Serializable]
    public class Deck<T> : IDeck<T>
    {
        private readonly IList<T> datas;
        private readonly DecrementalIndexes indexes;

        public int Count => indexes.Count;
        public bool IsEmpty => indexes.IsEmpty;

        public T Top => datas[indexes.Peek()];
        public T Bottom => datas[indexes.PeekFirst()];

        public Deck(IList<T> datas)
        {
            this.datas = datas;

            this.indexes = new DecrementalIndexes(datas.Count);
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

        public void Clear() => indexes.ResetIndex();

        public IEnumerator<T> GetEnumerator()
        {
            foreach (int index in indexes)
            {
                yield return datas[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}