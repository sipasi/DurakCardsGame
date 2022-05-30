
using System;
using System.Collections.Generic;

using UnityEngine.Assertions;

namespace Framework.Shared.Collections
{
    [Serializable]
    public class Storage<TKey> : IStorage<TKey>
    {
        private readonly Dictionary<TKey, object> dictionary;

        public int Count => dictionary.Count;


        public Storage() : this(4) { }
        public Storage(int catacity)
        {
            dictionary = new Dictionary<TKey, object>(catacity);
        }


        public void Store(TKey key, object data)
        {
            dictionary.Add(key, data);
        }

        public T Restore<T>(TKey key)
        {
            if (Contains(key) is false)
            {
                return default;
            }

            var value = dictionary[key];

            T data = (T)value;

            Assert.IsFalse(data == null, $"Can't cast value by the key[{key}]. Value type[{value.GetType()}]. Cast type [{typeof(T).Name}]");

            return data;
        }
        public T RestoreOrCreate<T>(TKey key) where T : new()
        {
            if (Contains(key) is false)
            {
                Store(key, new T());
            }

            T data = (T)dictionary[key];

            return data;
        }
        public T RestoreOrCreate<T>(TKey key, Func<T> factory)
        {
            if (Contains(key) is false)
            {
                Store(key, factory.Invoke());
            }

            T data = (T)dictionary[key];

            return data;
        }
        public T RestoreOrCreate<T>(TKey key, Func<TKey, T> factory)
        {
            if (Contains(key) is false)
            {
                Store(key, factory.Invoke(key));
            }

            T data = (T)dictionary[key];

            return data;
        }

        public bool Contains(TKey key) => dictionary.ContainsKey(key);

        public void Clear() => dictionary.Clear();

        public Dictionary<TKey, object>.Enumerator GetEnumerator() => dictionary.GetEnumerator();
    }
}