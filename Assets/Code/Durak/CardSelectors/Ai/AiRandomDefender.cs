using System.Collections.Generic;

using Framework.Durak.Datas;
using Framework.Durak.Datas.Extensions;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

using UnityEngine.Assertions;

namespace Framework.Durak.Cards.Selectors
{
    public sealed class AiRandomDefender : AiCardSelector
    {
        public override ICard GetCard(IReadOnlyList<Data> hand)
        {
            IReadonlyBoard<Data> board = Board;
            IReadonlyDeck<Data> deck = Deck;

            Data trump = deck.Bottom;

            Data last = board.Last();

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