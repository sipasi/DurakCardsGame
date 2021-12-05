
using ProjectCard.DurakModule.EntityModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
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