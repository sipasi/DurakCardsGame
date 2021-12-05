

using System;
using System.Collections.Generic;

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.CollectionModule
{
    [CreateAssetMenu(fileName = "PoolService", menuName = "MyAsset/Shared/ServiceModule/PoolService")]
    public class PoolService : ScriptableObject
    {
        private readonly Dictionary<Type, object> pairs = new Dictionary<Type, object>(capacity: 10);

        public T Get<T>() where T : class, new()
        {
            Queue<T> pool = GetOrCreatePool<T>();

            T result = pool.Count == 0 ? new T() : pool.Dequeue();

            ReuseEntity(result);

            return result;
        }
        public void Return<T>(T item) where T : class
        {
            var objects = GetOrCreatePool<T>();

            objects.Enqueue(item);
        }

        public void Clear() => pairs.Clear();

        private Queue<T> GetOrCreatePool<T>()
        {
            var type = typeof(T);

            if (pairs.ContainsKey(type) is true)
            {
                return (pairs[type] as Queue<T>)!;
            }

            var pool = new Queue<T>();

            pairs.Add(type, pool);

            return pool;
        }

        private void ReuseEntity(object entity)
        {
            if (entity is IReusable reusable) reusable.Reuse();
        }
    }
}