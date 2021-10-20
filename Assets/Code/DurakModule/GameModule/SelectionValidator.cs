
using System;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CardModule.ExtensionModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.CollectionModule.ExtensionModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;

using UnityEngine;

namespace ProjectCard.DurakModule.ValidatorModule
{
    public class SelectionValidator : MonoBehaviour
    {
        [Header("Players")]
        [SerializeField] private PlayerQueue playerQueue;

        [Header("Shared")]
        [SerializeField] private SharedEntities shared;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap entityDataMap;

        public bool Validate(ICard card)
        {
            PlayerInfo current = playerQueue.Current;

            Board<Data> board = shared.Board;
            Deck<Data> deck = shared.Deck;

            Data data = entityDataMap.Get(card);

            if (current.Hand.Contains(card) is false)
            {
                return false;
            }

            if (board.IsEmpty is false)
            {
                if (playerQueue.IsAttackerQueue && board.ContainsRank(data) is false)
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