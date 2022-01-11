using System;

namespace Framework.Durak.Datas
{
    [Serializable]
    public readonly struct Data
    {
        public readonly int suit;
        public readonly int rank;


        public Data(int suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
        }


        public readonly void Deconstruct(out int suit, out int rank)
        {
            suit = this.suit;
            rank = this.rank;
        }

        public static bool operator ==(in Data left, in Data right) => left.suit == right.suit && left.rank == right.rank;
        public static bool operator !=(in Data left, in Data right) => left.suit != right.suit && left.rank != right.rank;

        public bool Equals(in Data data)
        {
            return suit == data.suit &&
                   rank == data.rank;
        }
        public override bool Equals(object obj)
        {
            return obj is Data data && Equals(in data);
        }

        public override int GetHashCode()
        {
            var tuple = (suit, rank);

            int hash = tuple.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return $"Suit: {suit}, Rank: {rank}";
        }
    }
}