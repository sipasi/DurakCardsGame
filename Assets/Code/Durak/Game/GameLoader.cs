
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Framework.Durak.States;
using Framework.Shared.DependencyInjection;
using Framework.Shared.Events;
using Framework.Shared.States;

using UnityEngine;

namespace Framework.Durak.Game
{
    internal interface IGameLoader
    {
        ValueTask Load();
        ValueTask Unload();
    }

    public abstract class GameLoader : IGameLoader
    {
        private readonly ScriptableAction restart;

        private IStateMachine<DurakGameState> stateMachine;

        public GameLoader(ScriptableAction restart)
        {
            this.restart = restart;
        }

        protected virtual ValueTask BeforeLoad() => new(Task.CompletedTask);
        protected virtual ValueTask AfterLoad(IDiContainer container) => new(Task.CompletedTask);

        public async ValueTask Load()
        {
            await BeforeLoad();

            IDiContainer container = CreateDiContainer();

            IEnumerable<IGameInitializable> collection = UnityEngine.Object
                .FindObjectsOfType<MonoBehaviour>()
                .OfType<IGameInitializable>();

            foreach (var item in collection)
            {
                item.Initialize(container);
            }

            await AfterLoad(container);

            stateMachine = container.Get<IStateMachine<DurakGameState>>();

            restart.Event += OnRestart;

            DurakGameState state = GetState();

            stateMachine.Fire(state);
        }
        private void OnRestart()
        {
            stateMachine.Fire(DurakGameState.GameRestart);
        }

        public ValueTask Unload()
        {
            restart.Event -= OnRestart;

            return new(Task.CompletedTask);
        }

        protected abstract IDiContainer CreateDiContainer();
        protected abstract DurakGameState GetState();
    }
}