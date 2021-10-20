
using ProjectCard.DurakModule.StateModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    public class DurakGame : MonoBehaviour
    {
        [SerializeField] private DurakGameStateMachine stateMachine;

        [Header("Events")]
        [SerializeField] private EmptyAction gameRestart;


        private void OnEnable()
        {
            gameRestart.Action += OnGameRestart;
        }
        private void OnDisable()
        {
            gameRestart.Action -= OnGameRestart;
        }

        public void Initialize()
        {
            stateMachine.Initialize();

            stateMachine.Fire(DurakGameState.GameStart);
        }

        private void OnGameRestart()
        {
            stateMachine.Fire(DurakGameState.GameRestart);
        }
    }
}