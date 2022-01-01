using System.Collections.Generic;

using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.CardModule.ExtensionModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.Collections;

using UnityEngine.Assertions;

namespace ProjectCard.Durak.PlayerModule
{
    public sealed class AiRandomDefender : AiCardSelector
    {
        public override ICard GetCard(IPlayer player)
        {
            List<Data> hand = player.Hand;
            IBoard<Data> board = Board;
            IDeck<Data> deck = Deck;

            Data trump = deck.Bottom;

            board.TryGetLast(out var last);

            Assert.IsFalse(board.IsEmpty, "In defending state the board can't be empty");

            foreach (var data in hand)
            {
                if (data.CanBeat(last, trump))
                {
                    ICard card = ConvertToCard(data);

                    return card;
                }
            }

            return default;
        }
    }
}