
using System.Collections.Generic;

using Framework.Durak.Players;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class PlayerQueueEntity : MonoBehaviour, IPlayerQueueEntity
    {
        private IPlayerQueue<IPlayerEntity> queue;

        public IReadonlyPlayerQueue<IPlayerEntity> Value => queue;

        public IPlayerEntity Attacker => queue.Attacker;
        public IPlayerEntity Defender => queue.Defender;

        public void Initialize(IPlayerQueue<IPlayerEntity> queue) => this.queue = queue;

        public void SetAttackerQueue() => queue.SetAttackerQueue();
        public void SetDefenderQueue() => queue.SetDefenderQueue();
        public void SetAttackerQueue(IPlayerEntity attacker, IPlayerEntity defender)
            => queue.SetAttackerQueue(attacker, defender);
        public void SetDefenderQueue(IPlayerEntity attacker, IPlayerEntity defender)
            => queue.SetDefenderQueue(attacker, defender);

        internal IPlayerQueue<IPlayerEntity> GetQueue() => queue;
    }
}