
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;

using UnityEngine;

namespace ProjectCard.DurakModule.ValidatorModule
{
    public abstract class SelectionValidator : MonoBehaviour, IValidator<ICard>
    {
        [Header("Entities")]
        [SerializeField] private PlayerQueueEntity playerQueue;
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap map;

        protected IBoard<Data> Board => board.Value;
        protected IDeck<Data> Deck => deck.Value;
        protected IPlayerQueue PlayerQueue => playerQueue.Value;

        public abstract bool Validate(ICard value);

        protected Data ConvertToData(ICard card) => map.Get(card);

        protected void Deconstruct(out IBoard<Data> board, out IDeck<Data> deck, out IPlayerQueue playerQueue)
            => (board, deck, playerQueue) = (Board, Deck, PlayerQueue);
    }
}