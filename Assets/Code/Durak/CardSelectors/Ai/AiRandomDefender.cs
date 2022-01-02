using System.Collections.Generic;

using Framework.Durak.Cards.Extensions;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

using UnityEngine.Assertions;

namespace Framework.Durak.Cards.Selectors
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