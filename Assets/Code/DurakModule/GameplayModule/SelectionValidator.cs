
using System;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CardModule.ExtensionModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.CollectionModule.ExtensionModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.CardModule;

using UnityEngine;

namespace ProjectCard.DurakModule.ValidatorModule
{
    public class SelectionValidator : MonoBehaviour
    {
        [Header("Players")]
        [SerializeField] private PlayerQueueEntity playerQueue;

        [Header("Entities")]
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap entityDataMap;

        public bool Validate(ICard card)
        {
            var board = this.board.Entity;
            var deck = this.deck.Entity;
            var playerQueue = this.playerQueue.Entity;

            IPlayer current = playerQueue.Current;

            Data data = entityDataMap.Get(card);

            if (current.Hand.Contains(data) is false)
            {
                return false;
            }


            if (playerQueue.IsAttackerQueue)
            {
                if (board.IsEmpty is false && board.ContainsRank(data) is false)
                {
                    return false;
                }

                if (board.IsAttacksFull)
                {
                    return false;
                }
            }


            if (board.TryGetLast(out Data last))
            {
                bool canMove = playerQueue.Action switch
                {
                    PlayerActionType.Attack => board.ContainsRank(data),
                    PlayerActionType.Defend => data.CanBeat(last, deck.Bottom),

                    _ => throw new ArgumentException()
                };

                if (canMove is false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}