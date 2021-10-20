
using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.StateModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.BattleModule.StateModule
{
    public class BattleAttackingState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerStorage playerStorage;
        [SerializeField] private PlayerQueue playerQueue;

        [Header("Shared")]
        [SerializeField] private SharedEntities shared;
        [SerializeField] private BattlesCountInfo info;
        [SerializeField] private BattleResultInfo result;

        public override void Enter()
        {
            base.Enter();

            Assert.IsTrue(playerQueue.IsAttackerQueue,
                $"In a [{nameof(BattleAttackingState)}] the current player in [{nameof(PlayerQueue)}] must be attaker");

            PlayerInfo current = playerQueue.Current;
        }
    }
}