
using System;
using System.Diagnostics;


namespace Framework.Durak.Players
{
    [DebuggerDisplay("Name: {Name}. Selector: {Type}")]
    [Serializable]
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public PlayerType Type { get; set; }

        public IHand Hand { get; set; }
    }
}