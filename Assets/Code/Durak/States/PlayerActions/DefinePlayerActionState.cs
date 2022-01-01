
using ProjectCard.Durak.EntityModule;

using UnityEngine;

namespace ProjectCard.Durak.StateModule
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