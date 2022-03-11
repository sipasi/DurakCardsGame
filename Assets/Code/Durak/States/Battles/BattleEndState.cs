using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Shared.Collections;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.States.Battles
{
    public class BattleEndState : DurakState
    {
        private readonly IDeck<Data> deck;
        private readonly IBoard<Data> board;
        private readonly IPlaces<Transform> places;
        private readonly IPlayerStorage<IPlayer> storage;

        public BattleEndState(IStateMachine<DurakGameState> machine, IDeck<Data> deck, IBoard<Data> board, IPlaces<Transform> places, IPlayerStorage<IPlayer> storage)
            : base(machine)
        {
            this.deck = deck;
            this.board = board;
            this.places = places;
            this.storage = storage;
        }

        public override void Enter()
        {
            base.Enter();

            board.Clear();
            places.Clear();

            if (deck.IsEmpty)
            {
                var eliminated = Eliminator.Eliminate(storage.Active);

                storage.RemoveRange(eliminated);

                if (storage.Active.Count < 2)
                {
                    NextState(DurakGameState.GameEnd);

                    return;
                }
            }

            NextState(DurakGameState.BattleStart);
        }
    }
}