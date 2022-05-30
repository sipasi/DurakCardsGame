
using Cysharp.Threading.Tasks;

using Framework.Durak.Players;
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;
using Framework.Shared.Signals;

using UnityEngine;
using UnityEngine.UI;

namespace Framework.Durak.Game
{
    public class DurakGame : MonoBehaviour
    {
        [SerializeField] private DurakNewGameLoader newGameLoader;

        public UniTask LoadNewGame()
        {
            newGameLoader.Load();

            return UniTask.CompletedTask;
        }
        public UniTask UnloadGame()
        {
            return UniTask.CompletedTask;
        }
    }

    internal abstract class GameButtonListener<TSignal> : ServiceInitialization
        where TSignal : class, ISignal
    {
        private ISignal signal;

        [SerializeField] private Button button;

        public sealed override void Initialize(IDiContainer container) => signal = container.Get<TSignal>();
         
        private void OnEnable() => button.onClick.AddListener(Send);
        private void OnDisable() => button.onClick.RemoveListener(Send);

        protected void Send() => signal.Send();
    }
    internal class MainMenuListener : GameButtonListener<IMainMenuSignal> { }
    internal class GameRestartListener : GameButtonListener<IGameRestartSignal> { }
    internal class PlayerPassListener : GameButtonListener<IPlayerPassedSignal> { }
}