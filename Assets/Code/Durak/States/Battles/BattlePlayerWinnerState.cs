
using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Shared.Collections;
using Framework.Shared.States;

using System.Collections.Generic;

namespace Framework.Durak.States.Battles
{
    public abstract class BattlePlayerWinnerState : DurakState
    {
        private readonly IBoard<Data> board;
        private readonly IPlayerQueue<IPlayer> queue;

        protected BattlePlayerWinnerState(IStateMachine<DurakGameState> machine, IBoard<Data> board, IPlayerQueue<IPlayer> queue)
            : base(machine)
        {
            this.board = board;
            this.queue = queue;
        }

        public sealed override async void Enter()
        {
            IReadOnlyList<Data> all = board.All;

            await MoveCards(all);

            UpdatePlayerQueue(queue);

            NextState(DurakGameState.BattleEnd);
        }

        protected abstract UniTask MoveCards(IReadOnlyList<Data> datas);
        protected abstract void UpdatePlayerQueue(IPlayerQueue<IPlayer> entity);
    }
}