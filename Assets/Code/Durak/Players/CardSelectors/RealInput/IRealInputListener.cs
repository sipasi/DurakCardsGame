using System;

using Framework.Shared.Cards.Input;

namespace Framework.Durak.Players.Selectors
{
    public interface IRealInputListener
    {
        event CardInteraction Selected;
        event Action Passed;
    }
}