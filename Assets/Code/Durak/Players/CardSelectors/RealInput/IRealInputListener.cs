using System;

using Framework.Shared.Cards.Entities;
using Framework.Shared.Input;

namespace Framework.Durak.Players.Selectors
{
    public interface IRealInputListener
    {
        event Tapped<ICard> Tapped;
        event Action Passed;
    }
}