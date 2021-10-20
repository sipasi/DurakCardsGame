
using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CardModule.ExtensionModule;

namespace ProjectCard.DurakModule.CollectionModule.ExtensionModule
{
    public static class BoardExtension
    {
        public static bool ContainsSuit(this Board<Data> board, Data data)
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

        public static bool ContainsRank(this Board<Data> board, Data data)
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
    }
}
