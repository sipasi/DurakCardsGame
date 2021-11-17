using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using ProjectCard.Shared.SerializationModule;

namespace ProjectCard.Shared.CollectionModule
{
    [Serializable]
    public sealed class Map<T1, T2>
    {
        private readonly Dictionary<T1, T2> forward;
        private readonly Dictionary<T2, T1> reverse;

        public Indexer<T1, T2> Forward { get; }
        public Indexer<T2, T1> Reverse { get; }

        public int Count => forward.Count;


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
    }
}