
using Cysharp.Threading.Tasks;

using ProjectCard.Durak.EntityModule;
using ProjectCard.Durak.Gameplay;
using ProjectCard.Durak.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.Durak.StateModule
{
    public class GameRestartState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerStorageEntity playerStorage;

        [Header("Movement")]
        [SerializeField] private DurakCardMovementManager movement;

        [Header("Places")]
        [SerializeField] private Transform deckPlace;
        [SerializeField] private BoardPlaces boardPlaces;

        [Header("Entities")]
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;
        [SerializeField] private DiscardPileEntity discardPile;

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
            await movement.MoveToPlace(discardPile.Value, deckPlace, CardLookSide.Back);

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
            discardPile.Value.Clear();
        }
    }
}