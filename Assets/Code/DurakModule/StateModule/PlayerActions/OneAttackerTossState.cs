
using ProjectCard.DurakModule.PlayerModule;

namespace ProjectCard.DurakModule.StateModule
{
    public class OneAttackerTossState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.Toss;
        protected override DurakGameState AfterPass => DurakGameState.BattleAttackerWinner;

        protected override ICardSelector GetSelector(IPlayerCardSelection selection) => selection.Attack;

        protected override void UpdatePlayerQueue(IPlayerQueue queue) => queue.Action = PlayerActionType.Attack;
    }
}