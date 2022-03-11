
using Cysharp.Threading.Tasks;

using Framework.Durak.States;
using Framework.Shared.Events;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.Game
{
    public class DurakGame : MonoBehaviour
    {
        [SerializeField] private DiContainerHolder holder;

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
            var machine = holder.Container.Get<IStateMachine<DurakGameState>>();

            machine.Fire(DurakGameState.GameRestart);
        }
    }
}