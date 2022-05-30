using Cysharp.Threading.Tasks;

using Framework.Shared.Scenes;
using Framework.Shared.Services.Scenes;

namespace Framework.Durak.Services.Scenes
{
    internal class MainMenuLoader : IMainMenuLoader
    {
        private readonly ISceneLoadingService service;

        private readonly SceneReference loadingScrene;
        private readonly SceneReference menu;

        public MainMenuLoader(SceneReference loading, SceneReference menu)
        {
            this.service = new SceneLoadingService();

            this.loadingScrene = loading;
            this.menu = menu;
        }

        public async UniTask Load()
        {
            await service.Load(loadingScrene);

            BackgroundLoading.Complete complete = await service.LoadInBackground(menu);

            complete.Activate();
        }
    }
}
