

namespace ProjectCard.DurakModule.CardModule.ExtensionModule
{
    public static class DataExtension
    {
        public static bool CanBeat(this in Data left, in Data right, in Data trump)
        {
            if (left.EqualSuit(right))
            {
                return left.rank > right.rank;
            }

            return left.EqualSuit(trump) ? true : false;
        }

        public static bool EqualSuit(this in Data left, in Data right) => left.suit == right.suit;
        public static bool EqualRank(this in Data left, in Data right) => left.rank == right.rank;
    }
}