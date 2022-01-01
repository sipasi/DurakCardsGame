
using Cysharp.Threading.Tasks;

using ProjectCard.Durak.StateModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;

namespace ProjectCard.Durak.GameModule
{
    public class DurakGame : MonoBehaviour
    {
        [Header("State Machine")]
        [SerializeField] private DurakGameStateMachine stateMachine;

        [Header("Game Loaders")]
        [SerializeField] private DurakNewGameLoader newGameLoader;

        [Header("Events")]
        [SerializeField] private ScriptableAction gameRestart;


        private void OnEnable()
        {
            gameRestart.Action += OnGameRestart;
        }
        private void OnDisable()
        {
            gameRestart.Action -= OnGameRestart;
        }


        public UniTask LoadNewGame()
        {
            newGameLoader.Load();

            return UniTask.CompletedTask;
        }
         
        private void OnGameRestart()
        {
            stateMachine.Fire(DurakGameState.GameRestart);
        }
    }
}