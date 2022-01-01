
using UnityEngine;

namespace ProjectCard.Shared.Entities.Wrapper
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