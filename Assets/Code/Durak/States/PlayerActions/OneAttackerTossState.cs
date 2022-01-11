
using Framework.Durak.Cards.Selectors;
using Framework.Durak.Entities;
using Framework.Shared.Collections;

namespace Framework.Durak.States.Actions
{
    public class OneAttackerTossState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.Toss;
        protected override DurakGameState AfterPass => DurakGameState.BattleAttackerWinner;

        protected override ICardSelector GetSelector(IPlayerCardSelection selection) => selection.Attack;

        protected override void UpdatePlayerQueue(IPlayerQueueEntity queue) => queue.SetAttackerQueue();
    }
}