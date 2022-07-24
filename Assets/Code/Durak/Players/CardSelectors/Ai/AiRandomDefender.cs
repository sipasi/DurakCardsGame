using System.Collections.Generic;

using Framework.Durak.Datas;
using Framework.Durak.Datas.Extensions;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

using UnityEngine.Assertions;

namespace Framework.Durak.Players.Selectors
{
    public sealed class AiRandomDefender : AiCardSelector
    {
        private readonly IDeck<Data> deck;
        private readonly IBoard<Data> board;
        private readonly IMap<ICard, Data> map;

        public AiRandomDefender(IDeck<Data> deck, IBoard<Data> board, IMap<ICard, Data> map)
        {
            this.deck = deck;
            this.board = board;
            this.map = map;
        }

        public override ICard GetCard(IReadOnlyList<Data> hand)
        {
            Data trump = deck.Bottom;

            Data last = board.Last();

            Assert.IsFalse(board.IsEmpty, "In defending state the board can't be empty");

            foreach (var data in hand)
            {
                if (data.CanBeat(last, trump))
                {
                    ICard card = map.Get(data);

                    return card;
                }
            }

            return default;
        }
    }
}