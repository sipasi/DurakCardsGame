using ProjectCard.DurakModule.PlayerModule;

namespace ProjectCard.DurakModule.StateModule
{
    public sealed class PlayerAttackingState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.PlayerDefending;
        protected override DurakGameState AfterPass => DurakGameState.BattleDefenderWinner;

        protected override ICardSelector GetSelector(IPlayerCardSelection selection) => selection.Attack;

        protected override void UpdatePlayerQueue(IPlayerQueue queue) => queue.Action = PlayerActionType.Attack;
    }
}