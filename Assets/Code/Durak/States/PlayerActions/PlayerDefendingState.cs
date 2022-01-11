using Framework.Durak.Cards.Selectors;
using Framework.Durak.Entities;

namespace Framework.Durak.States.Actions
{
    public sealed class PlayerDefendingState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.PlayerAttacking;
        protected override DurakGameState AfterPass => DurakGameState.Toss;

        protected override ICardSelector GetSelector(IPlayerCardSelection selection) => selection.Defend;

        protected override void UpdatePlayerQueue(IPlayerQueueEntity entity) => queue.Action = PlayerActionType.Defend;
    }
}