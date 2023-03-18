using System;

using Framework.Shared.DependencyInjection;
using Framework.Shared.Services.Movements;
using Framework.Shared.Services.Pools;
using Framework.Shared.Services.Saves;
using Framework.Shared.Services.Scenes;
using Framework.Shared.Services.Storages;
using Framework.Shared.Services.Tasks;

using UnityEngine;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class ServiceModuleConfigurator : MonoBehaviour, IConfigurator
    {
        [Header("Movement")]
        [SerializeField] private MovementSpeed speed;

        [Header("Local File")]
        [SerializeField] private string directory;
        [SerializeField] private string fileName;
        [SerializeField] private string extention;

        public void Configure(ServiceBuilder builder)
        {
            IStorageService fileStorage = new LocalBinaryFileStorageService(directory, fileName, extention);

            builder.singleton
                .Add<MovementSpeed>(speed)
                .Add<ICardMovementService, CardMovementService>()
                .Add<ICardMovementManager, CardMovementManager>()
                .Add<IPoolService, PoolService>()
                .Add<ISaveService, GuidSaveService>()
                .Add<ISceneLoadingService, SceneLoadingService>()
                .Add<IStorageService>(fileStorage)
                .Add<ITaskServiceAsync, TaskServiceAsync>();
        }
    }
}