using Framework.Durak.Players;

namespace Framework.Durak.Cards.Selectors
{
    public interface IPlayerCardSelection
    {
        PlayerType Type { get; }

        ICardSelector Attack { get; }
        ICardSelector Defend { get; }
    }
}