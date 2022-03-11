using Framework.Durak.Datas;
using Framework.Durak.Gameplay.Handlers;
using Framework.Durak.Players;
using Framework.Durak.Players.Selectors;
using Framework.Shared.Collections;
using Framework.Shared.States;

namespace Framework.Durak.States.Actions
{
    public sealed class PlayerDefendingState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.PlayerAttacking;
        protected override DurakGameState AfterPass => DurakGameState.Toss;

        public PlayerDefendingState(IStateMachine<DurakGameState> machine, IDeck<Data> deck, IBoard<Data> board, IPlayerStorage<IPlayer> storage, IPlayerQueue<IPlayer> queue, IReadonlyIndexer<PlayerType, ISelectorsGroup> selectorsIndexer, IDefenderSelectionHandler selection)
            : base(machine, deck, board, storage, queue, selectorsIndexer, selection) { }

        protected override void UpdatePlayerQueue(IPlayerQueue<IPlayer> queue) => queue.SetDefenderQueue();

        protected override ICardSelector GetSelector(ISelectorsGroup group) => group.Defending;
    }
}