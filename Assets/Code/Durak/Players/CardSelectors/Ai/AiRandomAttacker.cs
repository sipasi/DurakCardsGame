using System.Collections.Generic;

using Framework.Durak.Collections.Extensions;
using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

using UnityEngine;

namespace Framework.Durak.Players.Selectors
{
    public sealed class AiRandomAttacker : AiCardSelector
    {
        private readonly IBoard<Data> board;
        private readonly IMap<ICard, Data> map;

        public AiRandomAttacker(IBoard<Data> board, IMap<ICard, Data> map)
        {
            this.board = board;
            this.map = map;
        }

        public override ICard GetCard(IReadOnlyList<Data> hand)
        {
            if (board.IsEmpty)
            {
                int random = Random.Range(0, hand.Count);

                Data data = hand[random];

                ICard card = map.Get(data);

                return card;
            }

            if (board.IsFull is false)
            {
                foreach (var data in hand)
                {
                    if (board.ContainsRank(data))
                    {
                        ICard card = map.Get(data);

                        return card;
                    }
                }
            }

            return default;
        }
    }
}