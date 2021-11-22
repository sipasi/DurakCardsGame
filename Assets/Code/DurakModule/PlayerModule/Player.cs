
using System;
using System.Collections.Generic;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.Shared.ViewModule;

namespace ProjectCard.DurakModule.PlayerModule
{
    [Serializable]
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
        public List<Data> Hand { get; set; }
        public CardLookSide LookSide { get; set; }
        public CardSelectorType Selector { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}. Position: {Position}. Selector: {Selector}";
        }
    }
}