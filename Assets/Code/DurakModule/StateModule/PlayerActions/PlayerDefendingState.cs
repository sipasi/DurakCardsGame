using ProjectCard.DurakModule.PlayerModule;

namespace ProjectCard.DurakModule.StateModule
{
    public sealed class PlayerDefendingState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.PlayerAttacking;
        protected override DurakGameState AfterPass => DurakGameState.Toss;

        protected override ICardSelector GetSelector(IPlayerCardSelection selection) => selection.Defend;

        protected override void UpdatePlayerQueue(IPlayerQueue queue) => queue.Action = PlayerActionType.Defend;
    }
}