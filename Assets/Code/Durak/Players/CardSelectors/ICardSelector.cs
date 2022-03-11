
using Framework.Shared.Cards.Entities;

namespace Framework.Durak.Players.Selectors
{
    public delegate void CardSelectedEventHandler(IPlayer player, ICard card);
    public delegate void PlayerPassedEventHandler(IPlayer player);

    public interface ICardSelector
    {
        event CardSelectedEventHandler Selected;
        event PlayerPassedEventHandler Passed;

        void Begin(IPlayer player);
        void End(IPlayer player);
    }
}