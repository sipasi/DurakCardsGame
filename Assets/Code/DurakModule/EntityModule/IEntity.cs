using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.DurakModule.EntityModule
{
    public interface IEntityViewPair<TEntity, TView>
    {
        TEntity Entity { get; }
        TView View { get; }
    }

    public class EntityViewPair<TEntity, TView> : MonoBehaviour, IEntityViewPair<TEntity, TView>
    {
        private TEntity entity;
        private TView view;

        public TEntity Entity => entity;
        public TView View => view;

        public void Instantiate(TEntity entity, TView view)
        {
            this.entity = entity;
            this.view = view;
        }

        public void Deconstruct(out TEntity entity, out TView view) => (entity, view) = (this.entity, this.view);
    }

    public class DeckEntity : EntityViewPair<IDeck<Data>, IDeckView>
    {
        [SerializeField] private CardEntityDataMap cardEntityDataMap;

        public void Shuffle(int times)
        {
            // TODO: Animations

            var (deck, view) = this;

            deck.Shuffle(times);

            ICard card = cardEntityDataMap.Get(deck.Bottom);

            view.Trump = card.View.Face;
        }

        public bool TryPop(out Data data)
        {
            var (deck, view) = this;

            if (deck.TryPop(out data) is false)
            {
                return false;
            }

            view.Count = deck.Count.ToString();

            return true;
        }
    }
}