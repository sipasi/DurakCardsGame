
using UnityEngine;

namespace Framework.Shared.Entities.Wrappers
{
    public abstract class EntityWrapper<T> : MonoBehaviour
    {
        private T entity;

        public T Value => entity;

        public void Initialize(T entity)
        {
            this.entity = entity;
        }
    }
}