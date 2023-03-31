#nullable enable

using Framework.Durak.Saves;
using Framework.Shared.DependencyInjection;
using Framework.Shared.IO;
using Framework.Shared.Saves;

using UnityEngine;

namespace Framework.Durak.Game.Configurators
{
    internal class SaveServiceInitialization : MonoBehaviour, IIdenticalGameConfigurator
    {
        public void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<SaveEntities>()
                .Add<IFile<SaveData>>(new LocalBinaryFile<SaveData>(SavePaths.durak.path));
        }
    }
}