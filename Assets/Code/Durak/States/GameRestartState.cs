
using Cysharp.Threading.Tasks;

using Framework.Durak.Entities;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Durak.States
{
    public class GameRestartState : DurakState
    {
        [Header("Players")]
        [SerializeField] private PlayerStorageEntity playerStorage;

        [Header("Movement")]
        [SerializeField] private DurakCardMovementManager movement;

        [Header("Places")]
        [SerializeField] private Transform deckPlace;

        [Header("Entities")]
        [SerializeField] private BoardEntity board;
        [SerializeField] private DeckEntity deck;
        [SerializeField] private DiscardPileEntity discardPile;

        public override async void Enter()
        {
            base.Enter();

            await MoveCards();

            await ClearEntities();

            NextState(DurakGameState.GameStart);
        }

        private async UniTask MoveCards()
        {
            await movement.MoveToPlace(board.Value.All, deckPlace, CardLookSide.Back);
            await movement.MoveToPlace(discardPile.Value, deckPlace, CardLookSide.Back);
        }

        private async UniTask ClearEntities()
        {
            playerStorage.Value.Restore();

            board.Clear();

            await deck.Reset();

            discardPile.Value.Clear();
        }
    }
}