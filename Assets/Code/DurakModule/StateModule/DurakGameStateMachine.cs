
using ProjectCard.DurakModule.BattleModule.StateModule;
using ProjectCard.Shared.StateModule;

using UnityEngine;

namespace ProjectCard.DurakModule.StateModule
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
        [SerializeField] private PlayerActionState playerAction;
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
            machine.DefineState(() => playerAction);
            machine.DefineState(() => oneAttackerTossState);

            machine.DefineStartTransition<GameStartState>(DurakGameState.GameStart);
            machine.DefineStartTransition<PlayerActionState>(DurakGameState.PlayerAction);

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
            machine.DefineTransition<PlayerActionState, PlayerActionState>(DurakGameState.PlayerAction);
            machine.DefineTransition<PlayerActionState, GameRestartState>(DurakGameState.GameRestart);
            machine.DefineTransition<PlayerActionState, OneAttackerTossState>(DurakGameState.Toss);
            machine.DefineTransition<PlayerActionState, BattleEndState>(DurakGameState.BattleEnd);

            machine.DefineTransition<PlayerActionState, BattleDefenderWinnerState>(DurakGameState.BattleDefenderWinner);

            machine.DefineTransition<OneAttackerTossState, OneAttackerTossState>(DurakGameState.Toss);
            machine.DefineTransition<OneAttackerTossState, BattleAttackerWinnerState>(DurakGameState.BattleAttackerWinner);

        }
        private void DefineBattleTransitions()
        {
            machine.DefineTransition<BattleFirstStartState, PlayerActionState>(DurakGameState.PlayerAction);
            machine.DefineTransition<BattleStartState, PlayerActionState>(DurakGameState.PlayerAction);

            machine.DefineTransition<BattleEndState, BattleStartState>(DurakGameState.BattleStart);

            machine.DefineTransition<BattleDefenderWinnerState, BattleEndState>(DurakGameState.BattleEnd);
            machine.DefineTransition<BattleAttackerWinnerState, BattleEndState>(DurakGameState.BattleEnd);

            machine.DefineTransition<BattleEndState, GameEndState>(DurakGameState.GameEnd);
        }
    }
}