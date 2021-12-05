using System;
using System.Collections.Generic;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.Shared.ViewModule;


namespace ProjectCard.DurakModule.PlayerModule
{
    public interface IPlayer
    {
        Guid Id { get; }

        string Name { get; }

        PlayerPosition Position { get; }

        List<Data> Hand { get; }
        CardLookSide LookSide { get; }

        CardSelectorType Selector { get; }
    }
}