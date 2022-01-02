using Framework.Durak.Players;

namespace Framework.Durak.Cards.Selectors
{
    public interface ICardSelector
    {
        void Begin(IPlayer player);
        void End(IPlayer player);
    }
}