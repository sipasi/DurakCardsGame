
using ProjectCard.Durak.StateModule.BattleModule;
using ProjectCard.Shared.StateModule;

using UnityEngine;

namespace ProjectCard.Durak.StateModule
{
    public class DurakGameStateMachine : MonoBehaviour, IStateMachine<DurakGameState>
    {
        private readonly StateMachine<DurakGameState> machine = new StateMachine<DurakGameState>();

        [Header("States")]
        [SerializeField] private GameStartState gameStart;
        [SerializeField] private GameEndState gameEnd;
        [SerializeField] private GameRestartState restartState;
        [SerializeField] private BattleFirstStartState battleFirstStart;
        [SerializeField] private BattleStartState battleStart;
        [SerializeField] private BattleAttackerWinnerState battleAttackerWinner;
        [SerializeField] private BattleDefenderWinnerState battleDefenderWinner;
        [SerializeField] private BattleEndState battleEnd;
        [SerializeField] private DefinePlayerActionState definePlayerAction;
        [SerializeField] private PlayerAttackingState playerAttacking;
        [SerializeField] private PlayerDefendingState playerDefending;
        [SerializeField] private OneAttackerTossState oneAttackerTossState;

        public void Initialize()
        {
            machine.DefineState(() => gameStart);
            machine.DefineState(() => gameEnd);
            machine.DefineState(() => restartState);
            machine.DefineState(() => battleFirstStart);
            machine.DefineState(() => battleStart);
            machine.DefineState(() => battleAttackerWinner);
            machine.DefineState(() => battleDefenderWinner);
            machine.DefineState(() => battleEnd);
            machine.DefineState(() => definePlayerAction);
            machine.DefineState(() => playerAttacking);
            machine.DefineState(() => playerDefending);
            machine.DefineState(() => oneAttackerTossState);

            machine.DefineStartTransition<GameStartState>(DurakGameState.GameStart);
            machine.DefineStartTransition<DefinePlayerActionState>(DurakGameState.DefinePlayerAction);

            DefineGameTransitions();
            DefinePlayerTransitions();
            DefineBattleTransitions();
        }


        public void Fire(DurakGameState trigger)
        {
            machine.Fire(trigger);
        }

        private void DefineGameTransitions()
        {
            machine.DefineTransition<GameStartState, BattleFirstStartState>(DurakGameState.BattleFirstStart);
            machine.DefineTransition<GameRestartState, GameStartState>(DurakGameState.GameStart);
            machine.DefineTransition<GameEndState, GameRestartState>(DurakGameState.GameRestart);
        }
        private void DefinePlayerTransitions()
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
        private void DefineBattleTransitions()
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