using Framework.Durak.Datas;
using Framework.Durak.Gameplay.Handlers;
using Framework.Durak.Players;
using Framework.Durak.Players.Selectors;
using Framework.Shared.Collections;
using Framework.Shared.States;

namespace Framework.Durak.States.Actions
{
    public sealed class PlayerAttackingState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.PlayerDefending;
        protected override DurakGameState AfterPass => DurakGameState.BattleDefenderWinner;

        public PlayerAttackingState(IStateMachine<DurakGameState> machine, IDeck<Data> deck, IBoard<Data> board, IPlayerStorage<IPlayer> storage, IPlayerQueue<IPlayer> queue, IReadonlyIndexer<PlayerType, ISelectorsGroup> selectorsIndexer, IAttackerSelectionHandler selection)
            : base(machine, deck, board, storage, queue, selectorsIndexer, selection) { }

        protected override void UpdatePlayerQueue(IPlayerQueue<IPlayer> queue) => queue.SetAttackerQueue();

        protected override ICardSelector GetSelector(ISelectorsGroup group) => group.Attacking;
    }
}