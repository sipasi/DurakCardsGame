using Framework.Durak.Cards.Selectors;
using Framework.Durak.Entities;

namespace Framework.Durak.States.Actions
{
    public sealed class PlayerAttackingState : PlayerActionState
    {
        protected override DurakGameState AfterCardSelected => DurakGameState.PlayerDefending;
        protected override DurakGameState AfterPass => DurakGameState.BattleDefenderWinner;

        protected override ICardSelector GetSelector(IPlayerCardSelection selection) => selection.Attack;

        protected override void UpdatePlayerQueue(IPlayerQueueEntity entity) => entity.Action = PlayerActionType.Attack;
    }
}