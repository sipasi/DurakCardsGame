
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.BattleModule.ScriptableModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.Shared.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
{
    public class GameRestartState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerStorageEntity playerStorage;

        [Header("Movement")]
        [SerializeField] private CardMovementManager movement;

        [Header("Places")]
        [SerializeField] private Transform deckPlace;

        [Header("Entities")]
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;
        [SerializeField] private TrashEntity trash;

        public override async void Enter()
        {
            base.Enter();

            await MoveCards();

            ClearEntities();

            NextState(DurakGameState.GameStart);
        }

        private async UniTask MoveCards()
        {
            await movement.MoveToPlace(board.Entity.All, deckPlace, CardLookSide.Back);
            await movement.MoveToPlace(trash.Entity, deckPlace, CardLookSide.Back);

            foreach (var player in playerStorage.Entity.All)
            {
                await movement.MoveToPlace(player.Hand, deckPlace, CardLookSide.Back);
            }
        }

        private void ClearEntities()
        {
            playerStorage.Entity.Restore();

            board.Entity.Clear();
            deck.Entity.Clear();
            trash.Entity.Clear();
        }
    }
}