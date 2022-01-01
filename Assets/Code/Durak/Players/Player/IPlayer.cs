using System;
using System.Collections.Generic;

using ProjectCard.Durak.CardModule;
using ProjectCard.Shared.ViewModule;


namespace ProjectCard.Durak.PlayerModule
{
    public interface IPlayer
    {
        Guid Id { get; }

        string Name { get; }

        PlayerPosition Position { get; }

        List<Data> Hand { get; }
        CardLookSide LookSide { get; }

        PlayerType Type { get; }
    }
}