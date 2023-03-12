using Framework.Durak.DependencyInjection;
using Framework.Durak.States;
using Framework.Shared.Events;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.Game
{
    public class DurakNewGameLoader : MonoBehaviour
    {
        [SerializeField] private DiContainerHolder holder;

        [SerializeField] private ScriptableAction restart;

        public void Load()
        {
            var machine = holder.Container.Get<IStateMachine<DurakGameState>>();

            machine.Fire(DurakGameState.GameStart);

            restart.Event += GameRestart;
        }
        public void Unload()
        {
            restart.Event -= GameRestart;
        }

        private void GameRestart()
        {
            var machine = holder.Container.Get<IStateMachine<DurakGameState>>();

            machine.Fire(DurakGameState.GameRestart);
        }
    }
}