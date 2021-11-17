
using UnityEngine;

namespace ProjectCard.Shared.EntityModule
{
    public abstract class GameplayEntity<T> : MonoBehaviour
    {
        private T entity;

        public T Entity => entity;

        public void Initialize(T entity)
        {
            this.entity = entity;
        }
    }
}
