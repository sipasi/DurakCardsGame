
using System;

namespace Framework.Durak.Players
{
    public interface IPlayer
    {
        Guid Id { get; }
        string Name { get; }

        PlayerType Type { get; }

        IHand Hand { get; }
    }
}