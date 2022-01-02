
using Framework.Durak.Cards;
using Framework.Durak.Collections;
using Framework.Durak.Entities;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Validators
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