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
        [SerializeField] private BattleStartState battleStart;
        [SerializeField] private BattleEndState battleEnd;
        [SerializeField] private PlayerActionState playerAction;

        public void Initialize()
        {
            machine.DefineState(() => gameStart);
            machine.DefineState(() => gameEnd);
            machine.DefineState(() => restartState);
            machine.DefineState(() => battleStart);
            machine.DefineState(() => battleEnd);
            machine.DefineState(() => playerAction);

            machine.DefineStartTransition<GameStartState>(DurakGameState.GameStart);

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
            machine.DefineTransition<GameStartState, BattleStartState>(DurakGameState.BattleStart);
            machine.DefineTransition<GameRestartState, GameStartState>(DurakGameState.GameStart);
        }
        private void DefinePlayerTransitions()
        {
            machine.DefineTransition<PlayerActionState, PlayerActionState>(DurakGameState.PlayerAction);
            machine.DefineTransition<PlayerActionState, GameRestartState>(DurakGameState.GameRestart);
            machine.DefineTransition<PlayerActionState, BattleEndState>(DurakGameState.BattleEnd);
        }
        private void DefineBattleTransitions()
        {
            machine.DefineTransition<BattleStartState, PlayerActionState>(DurakGameState.PlayerAction);
            machine.DefineTransition<BattleEndState, BattleStartState>(DurakGameState.BattleStart);
            machine.DefineTransition<BattleEndState, GameEndState>(DurakGameState.GameEnd);
        }
    }
}