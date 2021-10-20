using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CardModule.ExtensionModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.CollectionModule.ExtensionModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class AiRandomCardSelector : CardSelector
    {
        [SerializeField] private PlayerQueue queue;
        [SerializeField] private SharedEntities entities;
        [SerializeField] private CardEntityDataMap entityDataMap;

        public override void Begin()
        {
            base.Begin();

            if (queue.IsAttackerQueue)
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
            CardEntityDataStorage hand = Player.Hand;
            Board<Data> board = entities.Board;

            if (board.IsEmpty)
            {
                int random = UnityEngine.Random.Range(0, hand.Count);

                ICard card = hand.Cards[random];

                SelectCard(card);

                return;
            }

            foreach (var data in hand.Datas)
            {
                if (board.ContainsRank(data))
                {
                    ICard card = entityDataMap.Get(data);

                    SelectCard(card);

                    return;
                }
            }

            Pass();
        }
        private void Defending()
        {
            CardEntityDataStorage hand = Player.Hand;

            Board<Data> board = entities.Board;
            Deck<Data> deck = entities.Deck;

            Data trump = deck.Bottom;

            Assert.IsTrue(board.TryGetLast(out Data last), "In defending state the board can't be empty");

            foreach (var data in hand.Datas)
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