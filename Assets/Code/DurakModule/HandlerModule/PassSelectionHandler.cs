
using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.DurakModule.PlayerModule;

using UnityEngine;


namespace ProjectCard.DurakModule.HandlerModule
{
    public class PassSelectionHandler : MonoBehaviour
    {
        [Header("Players")]
        [SerializeField] private PlayerQueue playerQueue;

        [Header("Shared")]
        [SerializeField] private SharedEntities shared;
        [SerializeField] private BattleResultInfo result;


        public bool Handle()
        {
            if (shared.Board.IsEmpty)
            {
                return false;
            }

            if (playerQueue.IsAttackerQueue)
            {
                result.SetDefenderAsBattleWinner();
            }
            else
            {
                result.SetAttackerAsBattleWinner();
            }

            return true;
        }
    }
}