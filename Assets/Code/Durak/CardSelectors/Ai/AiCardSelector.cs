using Framework.Durak.Collections;
using Framework.Durak.Entities;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Cards.Selectors
{
    public abstract class AiCardSelector : CardSelector
    {
        [Header("Entities")]
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;
        [SerializeField] private CardEntityDataMap entityDataMap;

        protected IBoard<Data> Board => board.Value;
        protected IDeck<Data> Deck => deck.Value;

        protected ICard ConvertToCard(in Data data) => entityDataMap.Get(data);

        public abstract ICard GetCard(IPlayer player);

        public sealed override void Begin()
        {
            base.Begin();

            IPlayer player = Current;

            ICard card = GetCard(player);

            if (card == null)
            {
                Pass();

                return;
            }

            SelectCard(card);
        }
    }
}