using Framework.Durak.Game;
using Framework.Durak.States;
using Framework.Durak.States.Actions;
using Framework.Durak.States.Battles;
using Framework.Shared.DependencyInjection;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.Game.Configurators
{
    internal class StatesModuleConfigurator : MonoBehaviour, IIdenticalGameConfigurator
    {
        public void Configure(ServiceBuilder builder)
        {
            ConfigureStateMachine(builder);
            ConfigureStates(builder);
        }

        private static void ConfigureStateMachine(ServiceBuilder builder)
        {
            var machine = new StateMachine<DurakGameState>();

            builder.singleton
                .Add<IStateMachine<DurakGameState>>(machine)
                .Add<IStateTriggerInfo<DurakGameState>>(machine)
                .Add<IStateMachineDefinition<DurakGameState>>(machine);
        }
        private static void ConfigureStates(ServiceBuilder builder)
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