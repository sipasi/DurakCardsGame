
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.ViewModule;
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
        [SerializeField] private BoardPlaces boardPlaces;

        [Header("Entities")]
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;
        [SerializeField] private TrashEntity trash;

        public override async void Enter()
        {
            base.Enter();

            await MoveCards();

            ClearEntities();

            boardPlaces.Clear();

            NextState(DurakGameState.GameStart);
        }

        private async UniTask MoveCards()
        {
            await movement.MoveToPlace(board.Value.All, deckPlace, CardLookSide.Back);
            await movement.MoveToPlace(trash.Value, deckPlace, CardLookSide.Back);

            foreach (var player in playerStorage.Value.All)
            {
                await movement.MoveToPlace(player.Hand, deckPlace, CardLookSide.Back);
            }
        }

        private void ClearEntities()
        {
            playerStorage.Value.Restore();

            board.Value.Clear();
            deck.Value.Clear();
            trash.Value.Clear();
        }
    }
}