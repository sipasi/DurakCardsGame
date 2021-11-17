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

            if (queue.Entity.IsAttackerQueue)
            {
                Attacking();
            }
            else
            {
                Defending();
            }
        }

        private void Attacking()
        {
            List<Data> hand = Player.Hand;

            if (board.Entity.IsEmpty)
            {
                int random = UnityEngine.Random.Range(0, hand.Count);

                ICard card = entityDataMap.Get(hand[random]);

                SelectCard(card);

                return;
            }

            if (board.Entity.IsFull is false)
            {
                foreach (var data in hand)
                {
                    if (board.Entity.ContainsRank(data))
                    {
                        ICard card = entityDataMap.Get(data);

                        SelectCard(card);

                        return;
                    }
                }
            }

            Pass();
        }
        private void Defending()
        {
            List<Data> hand = Player.Hand;

            Data trump = deck.Entity.Bottom;
            Data last = default;

            Assert.IsTrue(board.Entity.TryGetLast(out last), "In defending state the board can't be empty");

            foreach (var data in hand)
            {
                if (data.CanBeat(last, trump))
                {
                    ICard card = entityDataMap.Get(data);

                    SelectCard(card);

                    return;
                }
            }

            Pass();
        }
    }
}