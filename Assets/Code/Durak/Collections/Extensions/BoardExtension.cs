
using System.Collections.Generic;

using Framework.Durak.Datas;
using Framework.Durak.Datas.Extensions;
using Framework.Shared.Collections;

namespace Framework.Durak.Collections.Extensions
{
    public static class BoardExtension
    {
        public static bool ContainsSuit(this IReadonlyBoard<Data> board, Data data)
        {
            foreach (var item in board)
            {
                if (item.EqualSuit(data))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsRank(this IReadonlyBoard<Data> board, Data data)
        {
            foreach (var item in board)
            {
                if (item.EqualRank(data))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CanToss(this IReadonlyBoard<Data> board, List<Data> attacker)
        {
            if (board.IsAttacksFull)
            {
                return false;
            }

            foreach (var card in attacker)
            {
                if (board.ContainsRank(card))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
