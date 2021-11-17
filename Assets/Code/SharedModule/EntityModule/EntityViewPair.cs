
using UnityEngine;

namespace ProjectCard.Shared.EntityModule
{
    public class EntityViewPair<TEntity, TView> : MonoBehaviour
    {
        private TEntity entity;
        private TView view;

        protected TEntity Entity => entity;
        protected TView View => view;

        public void Instantiate(TEntity entity, TView view)
        {
            this.entity = entity;
            this.view = view;
        }

        protected void Deconstruct(out TEntity entity, out TView view) => (entity, view) = (this.entity, this.view);
    }
}