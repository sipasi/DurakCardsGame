
using System;
using System.Diagnostics;

using Framework.Shared.Cards.Entities;

namespace Framework.Durak.Players
{
    [DebuggerDisplay("Name: {Name}. Selector: {Type}")]
    [Serializable]
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICardOwner Owner { get; set; }

        public PlayerType Type { get; set; }

        public IHand Hand { get; set; }
    }
}