
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
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