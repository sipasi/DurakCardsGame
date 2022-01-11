using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Entities;
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
        [SerializeField] private CardMap map;

        protected IReadonlyBoard<Data> Board => board.Value;
        protected IReadonlyDeck<Data> Deck => deck.Value;
        protected IReadonlyPlayerQueue<IPlayerEntity> PlayerQueue => playerQueue.Value;

        public abstract bool Validate(ICard value);

        protected Data ConvertToData(ICard card) => map.Get(card);

        protected void Deconstruct(out IReadonlyBoard<Data> board, out IReadonlyDeck<Data> deck, out IReadonlyPlayerQueue<IPlayerEntity> playerQueue)
            => (board, deck, playerQueue) = (Board, Deck, PlayerQueue);
    }
}