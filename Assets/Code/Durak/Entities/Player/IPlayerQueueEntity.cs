using Framework.Durak.Players;
using Framework.Shared.Collections;

namespace Framework.Durak.Entities
{
    public interface IPlayerQueueEntity
    {
        IReadonlyPlayerQueue<IPlayerEntity> Value { get; }

        void SetAttackerQueue();
        void SetDefenderQueue();
        void SetAttackerQueue(IPlayerEntity attacker, IPlayerEntity defender);
        void SetDefenderQueue(IPlayerEntity attacker, IPlayerEntity defender);
    }
}