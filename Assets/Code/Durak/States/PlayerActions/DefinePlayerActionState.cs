
using Framework.Durak.Entities;

using UnityEngine;

namespace Framework.Durak.States.Actions
{
    public class DefinePlayerActionState : DurakState
    {
        [SerializeField] private PlayerQueueEntity playerQueue;

        public override void Enter()
        {
            base.Enter();

            DurakGameState state = playerQueue.Value.IsAttackerQueue
                ? DurakGameState.PlayerAttacking
                : DurakGameState.PlayerDefending;

            NextState(state);
        }
    }
}