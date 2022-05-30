
using Cysharp.Threading.Tasks;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.States;

using System.Collections.Generic;

namespace Framework.Durak.States.Battles
{
    public class BattleDefenderWinnerState : BattlePlayerWinnerState
    {
        private readonly IDiscardPile discardPile;
        private readonly IDiscardPileCardMovement movement;

        public BattleDefenderWinnerState(IStateMachine<DurakGameState> machine, IPlayerQueue<IPlayer> queue, IBoard<Data> board, IDiscardPile discardPile, IDiscardPileCardMovement movement)
            : base(machine, board, queue)
        {
            this.discardPile = discardPile;
            this.movement = movement;
        }

        protected override UniTask MoveCards(IReadOnlyList<Data> datas)
        {
            discardPile.AddRange(datas);

            return movement.MoveTo(datas);

        }
        protected override void UpdatePlayerQueue(IPlayerQueue<IPlayer> queue)
        {
            queue.SetAttackerQueue(
                attacker: queue.Defender,
                defender: queue.GetNextFrom(queue.Defender));
        }
    }
}