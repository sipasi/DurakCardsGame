using System;

namespace Framework.Durak.Datas
{
    [Serializable]
    public readonly struct Data
    {
        public readonly int suit;
        public readonly int rank;


        public Data(int suit, int rank) => (this.suit, this.rank) = (suit, rank);


        public static bool operator ==(in Data left, in Data right) => left.suit == right.suit && left.rank == right.rank;
        public static bool operator !=(in Data left, in Data right) => left.suit != right.suit && left.rank != right.rank;

        public bool Equals(in Data data)
        {
            bool sameSuit = suit == data.suit;
            bool sameRank = rank == data.rank;

            bool equal = sameSuit && sameRank;

            return equal;
        }
        public override bool Equals(object obj)
        {
            return obj is Data data && Equals(in data);
        }

        public override int GetHashCode()
        {
            ValueTuple<int, int> tuple = (suit, rank);

            int hash = tuple.GetHashCode();

            return hash;
        }

        public void Deconstruct(out int suit, out int rank) => (suit, rank) = (this.suit, this.rank);

        public override string ToString() => $"Suit: {suit}, Rank: {rank}";
    }
}