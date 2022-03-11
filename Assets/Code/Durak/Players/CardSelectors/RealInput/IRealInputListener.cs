using Framework.Shared.Cards.Entities;

using System;

namespace Framework.Durak.Players.Selectors
{
    public interface IRealInputListener
    {
        event Action<ICard> Selected;
        event Action Passed;
    }
}