
using System;

namespace Framework.Durak.Players
{
    public interface IPlayer
    {
        Guid Id { get; }
        string Name { get; }

        Place Place { get; }

        PlayerType Type { get; }

        IHand Hand { get; }
    }
}