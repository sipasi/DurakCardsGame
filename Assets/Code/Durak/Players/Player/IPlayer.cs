using System;
using System.Collections.Generic;

using Framework.Durak.Cards;
using Framework.Shared.Cards.Views;


namespace Framework.Durak.Players
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