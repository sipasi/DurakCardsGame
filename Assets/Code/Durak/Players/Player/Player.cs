
using System;
using System.Collections.Generic;

using Framework.Durak.Cards;
using Framework.Shared.Cards.Views;

namespace Framework.Durak.Players
{
    [Serializable]
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
        public List<Data> Hand { get; set; }
        public CardLookSide LookSide { get; set; }
        public PlayerType Type { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}. Position: {Position}. Selector: {Type}";
        }
    }
}