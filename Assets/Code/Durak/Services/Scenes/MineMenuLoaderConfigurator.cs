
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;
using Framework.Shared.Scenes;

using UnityEngine;

namespace Framework.Durak.Services.Scenes
{
    internal class MineMenuLoaderConfigurator : ServiceConfigurator
    {
        [SerializeField] private SceneReference loadingScrene;
        [SerializeField] private SceneReference menu;

        public override void Configure(ServiceBuilder builder)
        {
            IMainMenuLoader loader = new MainMenuLoader(loadingScrene, menu);

            builder.singleton.Add(loader);
        }
    }
}
