
using System;
using System.Collections.Generic;

using ProjectCard.Durak.CardModule;
using ProjectCard.Shared.ViewModule;

namespace ProjectCard.Durak.PlayerModule
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