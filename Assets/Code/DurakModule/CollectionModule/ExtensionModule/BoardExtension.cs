
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CardModule.ExtensionModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.CollectionModule;

namespace ProjectCard.DurakModule.CollectionModule.ExtensionModule
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

        public static bool CanToss(this IReadonlyBoard<Data> board, IPlayer attacker)
        {
            if (board.IsAttacksFull)
            {
                return false;
            }

            foreach (var card in attacker.Hand)
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
