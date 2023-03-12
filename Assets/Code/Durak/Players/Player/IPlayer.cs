
using System;

using Framework.Shared.Cards.Entities;

namespace Framework.Durak.Players
{
    public interface IPlayer
    {
        Guid Id { get; }
        string Name { get; }

        ICardOwner Owner { get; }

        PlayerType Type { get; }

        IHand Hand { get; }
    }
}