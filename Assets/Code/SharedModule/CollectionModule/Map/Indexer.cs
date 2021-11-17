using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectCard.Shared.CollectionModule
{
    [Serializable]
    public class Indexer<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly Dictionary<TKey, TValue> dictionary;

        public int Count => dictionary.Count;

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

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => dictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => dictionary.GetEnumerator();
    }
}