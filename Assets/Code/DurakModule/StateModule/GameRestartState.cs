
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
{
    public class GameRestartState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerStorage playerStorage;

        [Header("Movement")]
        [SerializeField] private CardMovementManager movement;

        [Header("Places")]
        [SerializeField] private Transform deck;

        [Header("Scriptable")]
        [SerializeField] private SharedEntities shared;
        [SerializeField] private BattleMovementInfo movementInfo;
        [SerializeField] private BattlesCountInfo countInfo;
        [SerializeField] private BattleResultInfo resultInfo;

        public override async void Enter()
        {
            base.Enter();

            await MoveCards();

            ClearEntities();

            machine.Fire(DurakGameState.GameStart);
        }

        private async UniTask MoveCards()
        {
            await movement.MoveToPlace(shared.Board.All, deck, CardLookSide.Back);

            foreach (var player in playerStorage.All)
            {
                await movement.MoveToPlace(player.Hand.Cards, deck, CardLookSide.Back);
            }
        }
        private void ClearEntities()
        {
            playerStorage.Restore();

            movementInfo.Clear();
            countInfo.Clear();
            resultInfo.Clear();

            shared.Board.Clear();
            shared.Deck.Reset();
        }
    }
}