
using Framework.Durak.Players;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class PlayerEntity : MonoBehaviour, IPlayerEntity
    {
        public IReadonlyPlayer Value { get; private set; }

        public IHand Hand { get; private set; }

        public ICardSelector Attacking { get; private set; }
        public ICardSelector Defending { get; private set; }

        public void Initialize(IPlayer player, IHand hand, ICardSelector attacking, ICardSelector defending)
            => (Value, Hand, Attacking, Defending) = (player, hand, attacking, defending);
    }
}