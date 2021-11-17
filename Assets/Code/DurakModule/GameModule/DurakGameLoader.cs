
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.StateModule;
using ProjectCard.Shared.EventModule;
using ProjectCard.Shared.GameModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    public class DurakGameLoader : GameLoader
    {
        [Header("State Machine")]
        [SerializeField] private DurakGameStateMachine stateMachine;

        [Header("Game Loaders")]
        [SerializeField] private DurakNewGameLoader newGameLoader;
        [SerializeField] private DurakSavedGameLoader savedGameLoader;

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


        public override async UniTask LoadNewGame()
        {
            await UniTask.Delay(millisecondsDelay: 1000);

            newGameLoader.Load();
        }

        public override async UniTask LoadSavedGame()
        {
            await UniTask.Delay(millisecondsDelay: 1000);

            await savedGameLoader.Load();
        }

        private void OnGameRestart()
        {
            stateMachine.Fire(DurakGameState.GameRestart);
        }
    }
}