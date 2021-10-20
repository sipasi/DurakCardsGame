using System.Collections.Generic;

namespace ProjectCard.Shared.CollectionModule
{
    public sealed class Map<T1, T2>
    {
        private readonly Dictionary<T1, T2> forward;
        private readonly Dictionary<T2, T1> reverse;

        public Indexer<T1, T2> Forward { get; private set; }
        public Indexer<T2, T1> Reverse { get; private set; }


        public Map() : this(capacity: 4) { }
        public Map(int capacity)
        {
            this.forward = new Dictionary<T1, T2>(capacity);
            this.reverse = new Dictionary<T2, T1>(capacity);

            this.Forward = new Indexer<T1, T2>(forward);
            this.Reverse = new Indexer<T2, T1>(reverse);
        }
        public Map(IReadOnlyList<T1> firstList, IReadOnlyList<T2> secondList) : this(capacity: firstList.Count)
        {
            if (firstList.Count != secondList.Count)
            {
                throw new System.ArgumentException();
            }

            for (int i = 0; i < firstList.Count; i++)
            {
                T1 first = firstList[i];
                T2 second = secondList[i];

                Add(first, second);
            }
        }

        public void Add(T1 first, T2 second)
        {
            forward.Add(first, second);
            reverse.Add(second, first);
        }

        public sealed class Indexer<TKey, TValue>
        {
            private readonly Dictionary<TKey, TValue> dictionary;

            public int Length => dictionary.Count;

            public Indexer(Dictionary<TKey, TValue> dictionary)
            {
                this.dictionary = dictionary;
            }

            public TValue this[TKey index]
            {
                get => dictionary[index];
                set => dictionary[index] = value;
            }

            public Dictionary<TKey, TValue>.Enumerator GetEnumerator() => dictionary.GetEnumerator();
        }
    }
}