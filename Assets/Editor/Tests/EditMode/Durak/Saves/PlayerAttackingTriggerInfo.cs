using Framework.Durak.States;
using Framework.Shared.States;

namespace Framework.Durak.Saves
{
    sealed class PlayerAttackingTriggerInfo : IStateTriggerInfo<DurakGameState>
    {
        public DurakGameState CurrentTrigger => DurakGameState.PlayerAttacking;
    }
}
