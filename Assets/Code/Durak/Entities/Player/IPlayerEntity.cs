

using Framework.Durak.Players;

namespace Framework.Durak.Entities
{
    public interface IPlayerEntity
    {
        IReadonlyPlayer Value { get; }

        IHand Hand { get; }

        ICardSelector Attacking { get; }
        ICardSelector Defending { get; }
    }
}
