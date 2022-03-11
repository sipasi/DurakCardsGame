using Framework.Durak.Datas;
using Framework.Durak.Gameplay.Handlers;
using Framework.Durak.Players;
using Framework.Durak.Players.Selectors;
using Framework.Shared.Collections;
using Framework.Shared.States;

namespace Framework.Durak.States.Actions
{
    public class OneAttackerTossState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.Toss;
        protected override DurakGameState AfterPass => DurakGameState.BattleAttackerWinner;

        public OneAttackerTossState(IStateMachine<DurakGameState> machine, IDeck<Data> deck, IBoard<Data> board, IPlayerStorage<IPlayer> storage, IPlayerQueue<IPlayer> queue, IReadonlyIndexer<PlayerType, ISelectorsGroup> selectorsIndexer, IAttackerSelectionHandler selection)
            : base(machine, deck, board, storage, queue, selectorsIndexer, selection) { }

        protected override void UpdatePlayerQueue(IPlayerQueue<IPlayer> queue) => queue.SetAttackerQueue();

        protected override ICardSelector GetSelector(ISelectorsGroup group) => group.Attacking;
    }
}