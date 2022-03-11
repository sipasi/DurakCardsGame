
using Framework.Durak.States.Actions;
using Framework.Durak.States.Battles;
using Framework.Shared.DependencyInjection;

namespace Framework.Durak.States
{
    internal class StatesConfigurator
    {
        public void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<GameStartState>()
                .Add<GameEndState>()
                .Add<GameRestartState>()
                .Add<BattleFirstStartState>()
                .Add<BattleStartState>()
                .Add<BattleAttackerWinnerState>()
                .Add<BattleDefenderWinnerState>()
                .Add<BattleEndState>()
                .Add<DefinePlayerActionState>()
                .Add<PlayerAttackingState>()
                .Add<PlayerDefendingState>()
                .Add<OneAttackerTossState>();
        }
    }
}