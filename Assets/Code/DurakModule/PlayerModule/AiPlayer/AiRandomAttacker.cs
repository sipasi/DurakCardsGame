using System.Collections.Generic;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule.ExtensionModule;
using ProjectCard.Shared.CardModule;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public sealed class AiRandomAttacker : AiCardSelector
    {
        public override ICard GetCard(IPlayer player)
        {
            List<Data> hand = player.Hand;

            var board = Board;

            if (board.IsEmpty)
            {
                int random = Random.Range(0, hand.Count);

                ICard card = ConvertToCard(hand[random]);

                return card;
            }

            if (board.IsFull is false)
            {
                foreach (var data in hand)
                {
                    if (board.ContainsRank(data))
                    {
                        ICard card = ConvertToCard(data);

                        return card;
                    }
                }
            }

            return default;
        }
    }
}