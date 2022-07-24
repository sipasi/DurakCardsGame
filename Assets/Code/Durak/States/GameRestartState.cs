
using Cysharp.Threading.Tasks;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.Services.Movements;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.States
{
    public class GameRestartState : DurakState
    {
        private readonly IDeck<Data> deck;
        private readonly IBoard<Data> board;
        private readonly IPlaces<Transform> places;
        private readonly IDiscardPile discard;
        private readonly IPlayerStorage<IPlayer> storage;

        private readonly IDeckCardMovement movement;

        public GameRestartState(IStateMachine<DurakGameState> machine, IDeck<Data> deck, IBoard<Data> board, IPlaces<Transform> places, IDiscardPile discard, IPlayerStorage<IPlayer> storage, IDeckCardMovement movement)
            : base(machine)
        {
            this.deck = deck;
            this.board = board;
            this.places = places;
            this.discard = discard;
            this.storage = storage;
            this.movement = movement;
        }

        public override async void Enter()
        {
            base.Enter();

            await MoveCards();

            ClearEntities();

            NextState(DurakGameState.GameStart);
        }

        private async UniTask MoveCards()
        {
            await movement.MoveTo(board.All);
            await movement.MoveTo(discard);

            foreach (var player in storage.All)
            {
                if (player.Hand.IsEmpty())
                {
                    continue;
                }

                await movement.MoveTo(player.Hand);
            }
        }

        private void ClearEntities()
        {
            storage.Restore();

            board.Clear();

            places.Clear();

            deck.Clear();

            discard.Clear();
        }
    }
}