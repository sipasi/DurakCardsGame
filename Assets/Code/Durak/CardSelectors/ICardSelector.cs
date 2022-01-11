using Framework.Durak.Players;

namespace Framework.Durak.Cards.Selectors
{
    public interface ICardSelector
    {
        void Begin(IReadonlyPlayer player);
        void End(IReadonlyPlayer player);
    }
}