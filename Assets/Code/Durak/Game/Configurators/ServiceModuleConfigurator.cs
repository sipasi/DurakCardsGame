using System;

using Framework.Durak.Game.Initializators;
using Framework.Shared.DependencyInjection;
using Framework.Shared.Services.Movements;
using Framework.Shared.Services.Pools;
using Framework.Shared.Services.Scenes;
using Framework.Shared.Services.Tasks;

using UnityEngine;

namespace Framework.Durak.Game.Configurators
{
    [Serializable]
    internal class ServiceModuleConfigurator : MonoBehaviour, IIdenticalGameConfigurator
    {
        [Header("Movement")]
        [SerializeField] private MovementSpeed speed;

        [Header("Local File")]
        [SerializeField] private string directory;
        [SerializeField] private string fileName;
        [SerializeField] private string extention;

        public void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<MovementSpeed>(speed)
                .Add<ICardMovementService, CardMovementService>()
                .Add<ICardMovementManager, CardMovementManager>()
                .Add<IPoolService, PoolService>()
                .Add<ISceneLoadingService, SceneLoadingService>()
                .Add<ITaskServiceAsync, DurakTaskServiceAsync>();
        }

        private sealed class DurakTaskServiceAsync : TaskServiceAsync
        {
            public DurakTaskServiceAsync()
            {
                GameObject gameObject = new(name: nameof(TaskServiceExecutor));

                var taskService = gameObject.AddComponent<TaskServiceExecutor>();

                taskService.Task = this;

                taskService.Enable();
            }
        }
    }
}