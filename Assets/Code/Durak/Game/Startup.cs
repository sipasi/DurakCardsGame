
using Framework.Durak.States;
using Framework.Shared.DependencyInjection;
using Framework.Shared.Services.Tasks;

using UnityEngine;

namespace Framework.Durak.Game
{
    internal class Startup : MonoBehaviour
    {
        [SerializeField] private TaskServiceExecutor taskServiceExecutor;
        [SerializeField] private DiContainerHolder holder;
        [SerializeField] private DiContainerBuilder builder;

        [SerializeField] private DurakGame gameLoader;

        private async void Awake()
        {
            DurakStateMachineInitializer stateMachineInitializer = new DurakStateMachineInitializer();

            IDiContainer container = holder.Container = builder.Build();

            stateMachineInitializer.Initialize(container);

            taskServiceExecutor.StartTaskService(container.Get<ITaskServiceAsync>());

            await gameLoader.LoadNewGame();
        }
    }
}