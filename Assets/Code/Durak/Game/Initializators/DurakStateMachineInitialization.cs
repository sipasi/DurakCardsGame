
using Framework.Durak.States;
using Framework.Durak.States.Actions;
using Framework.Durak.States.Battles;
using Framework.Shared.DependencyInjection;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.Game.Initializators
{
    internal class DurakStateMachineInitialization : MonoBehaviour, IGameInitializable
    {
        public void Initialize(IDiContainer container)
        {
            IStateMachineDefinition<DurakGameState> machine = container.Get<IStateMachineDefinition<DurakGameState>>();

            machine.DefineState(container.Get<GameStartState>);
            machine.DefineState(container.Get<GameEndState>);
            machine.DefineState(container.Get<GameRestartState>);
            machine.DefineState(container.Get<BattleFirstStartState>);
            machine.DefineState(container.Get<BattleStartState>);
            machine.DefineState(container.Get<BattleAttackerWinnerState>);
            machine.DefineState(container.Get<BattleDefenderWinnerState>);
            machine.DefineState(container.Get<BattleEndState>);
            machine.DefineState(container.Get<DefinePlayerActionState>);
            machine.DefineState(container.Get<PlayerAttackingState>);
            machine.DefineState(container.Get<PlayerDefendingState>);
            machine.DefineState(container.Get<OneAttackerTossState>);

            machine.DefineStartTransition<GameStartState>(DurakGameState.GameStart);
            machine.DefineStartTransition<DefinePlayerActionState>(DurakGameState.DefinePlayerAction);

            machine.DefineStartTransition<PlayerAttackingState>(DurakGameState.PlayerAttacking);
            machine.DefineStartTransition<PlayerDefendingState>(DurakGameState.PlayerDefending);
            machine.DefineStartTransition<OneAttackerTossState>(DurakGameState.Toss);


            DefineGameTransitions(machine);
            DefinePlayerTransitions(machine);
            DefineBattleTransitions(machine);
        }

        private void DefineGameTransitions(IStateMachineDefinition<DurakGameState> machine)
        {
            machine.DefineTransition<GameStartState, BattleFirstStartState>(DurakGameState.BattleFirstStart);
            machine.DefineTransition<GameRestartState, GameStartState>(DurakGameState.GameStart);
            machine.DefineTransition<GameEndState, GameRestartState>(DurakGameState.GameRestart);
        }
        private void DefinePlayerTransitions(IStateMachineDefinition<DurakGameState> machine)
        {
            machine.DefineTransition<DefinePlayerActionState, PlayerDefendingState>(DurakGameState.PlayerDefending);
            machine.DefineTransition<DefinePlayerActionState, PlayerAttackingState>(DurakGameState.PlayerAttacking);
            machine.DefineTransition<PlayerAttackingState, PlayerDefendingState>(DurakGameState.PlayerDefending);
            machine.DefineTransition<PlayerDefendingState, PlayerAttackingState>(DurakGameState.PlayerAttacking);

            machine.DefineTransition<PlayerAttackingState, GameRestartState>(DurakGameState.GameRestart);
            machine.DefineTransition<PlayerDefendingState, GameRestartState>(DurakGameState.GameRestart);

            machine.DefineTransition<PlayerDefendingState, OneAttackerTossState>(DurakGameState.Toss);
            machine.DefineTransition<PlayerAttackingState, OneAttackerTossState>(DurakGameState.Toss);

            machine.DefineTransition<PlayerDefendingState, BattleEndState>(DurakGameState.BattleEnd);
            machine.DefineTransition<PlayerAttackingState, BattleEndState>(DurakGameState.BattleEnd);

            machine.DefineTransition<PlayerAttackingState, BattleDefenderWinnerState>(DurakGameState.BattleDefenderWinner);

            machine.DefineTransition<OneAttackerTossState, OneAttackerTossState>(DurakGameState.Toss);
            machine.DefineTransition<OneAttackerTossState, BattleAttackerWinnerState>(DurakGameState.BattleAttackerWinner);

        }
        private void DefineBattleTransitions(IStateMachineDefinition<DurakGameState> machine)
        {
            machine.DefineTransition<BattleFirstStartState, PlayerAttackingState>(DurakGameState.PlayerAttacking);
            machine.DefineTransition<BattleStartState, PlayerAttackingState>(DurakGameState.PlayerAttacking);

            machine.DefineTransition<BattleEndState, BattleStartState>(DurakGameState.BattleStart);

            machine.DefineTransition<BattleDefenderWinnerState, BattleEndState>(DurakGameState.BattleEnd);
            machine.DefineTransition<BattleAttackerWinnerState, BattleEndState>(DurakGameState.BattleEnd);

            machine.DefineTransition<BattleEndState, GameEndState>(DurakGameState.GameEnd);
        }
    }
}