#nullable enable

using System.Collections.Generic;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CardModule.ExtensionModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.CollectionModule.ExtensionModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.Shared.CardModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class AiRandomCardSelector : CardSelector
    {
        [SerializeField] private PlayerQueueEntity queue;
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;
        [SerializeField] private CardEntityDataMap entityDataMap;

        public override void Begin()
        {
            base.Begin();

            ICard? card = queue.Value.IsAttackerQueue
                ? Attacking()
                : Defending();

            if (card is null)
            {
                Pass();

                return;
            }

            SelectCard(card);
        }

        private ICard? Attacking()
        {
            List<Data> hand = Current.Hand;

            if (board.Value.IsEmpty)
            {
                int random = UnityEngine.Random.Range(0, hand.Count);

                ICard card = entityDataMap.Get(hand[random]);

                return card;
            }

            if (board.Value.IsFull is false)
            {
                foreach (var data in hand)
                {
                    if (board.Value.ContainsRank(data))
                    {
                        ICard card = entityDataMap.Get(data);

                        return card;
                    }
                }
            }

            return default;
        }
        private ICard? Defending()
        {
            List<Data> hand = Current.Hand;

            Data trump = deck.Value.Bottom;
            Data last = default;

            Assert.IsTrue(board.Value.TryGetLast(out last), "In defending state the board can't be empty");

            foreach (var data in hand)
            {
                if (data.CanBeat(last, trump))
                {
                    ICard card = entityDataMap.Get(data);

                    return card;
                }
            }

            return default;
        }
    }
}