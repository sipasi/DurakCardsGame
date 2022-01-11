using System.Collections.Generic;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
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
        [SerializeField] private CardMap entityDataMap;

        protected IReadonlyBoard<Data> Board => board.Value;
        protected IReadonlyDeck<Data> Deck => deck.Value;

        protected ICard ConvertToCard(in Data data) => entityDataMap.Get(data);

        public abstract ICard GetCard(IReadOnlyList<Data> hand);

        public sealed override void Begin()
        {
            base.Begin();

            IReadonlyPlayer player = Current;

            ICard card = GetCard(player.Hand);

            if (card == null)
            {
                Pass();

                return;
            }

            SelectCard(card);
        }
    }
}