using Framework.Durak.Cards.Selectors;
using Framework.Durak.Players;

namespace Framework.Durak.States.Actions
{
    public sealed class PlayerDefendingState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.PlayerAttacking;
        protected override DurakGameState AfterPass => DurakGameState.Toss;

        protected override ICardSelector GetSelector(IPlayerCardSelection selection) => selection.Defend;

        protected override void UpdatePlayerQueue(IPlayerQueue queue) => queue.Action = PlayerActionType.Defend;
    }
}