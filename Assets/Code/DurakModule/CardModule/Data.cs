#nullable enable

using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ProjectCard.DurakModule.CardModule
{
    [Serializable]
    public readonly struct Data : ISerializable
    {
        public readonly int suit;
        public readonly int rank;


        public Data(int suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
        }
        /// <summary>
        /// This constructor is used for deserialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="text"></param>
        public Data(SerializationInfo info, StreamingContext context)
        {
            suit = info.GetInt32(nameof(suit));
            rank = info.GetInt32(nameof(rank));
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
        public override bool Equals(object? obj)
        {
            return obj is Data data && Equals(in data);
        }

        public override int GetHashCode()
        {
            var tuple = (suit, rank);

            int hash = tuple.GetHashCode();

            return hash;
        }

        /// <summary>
        /// This method is called during serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(suit), suit);
            info.AddValue(nameof(rank), rank);
        }

        public override string ToString()
        {
            return $"Suit: {suit}, Rank: {rank}";
        }
    }
}