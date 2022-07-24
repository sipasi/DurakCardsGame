
using Cysharp.Threading.Tasks;

using Framework.Shared.Scenes;

using UnityEngine;

namespace Framework.Shared.Services.Scenes
{
    [CreateAssetMenu(fileName = "SceneLoader", menuName = "MyAsset/Shared/Scenes/OneSceneLoader")]
    public class OneSceneLoader : SceneLoader
    {
        [SerializeField] private SceneReference main;

        public async void LoadSync() => await Load();

        public override async UniTask Load()
        {
            await LoadScreen();

            BackgroundLoading.Complete complete = await LoadingService.LoadInBackground(main);

            complete.Activate();
        }
    }
}
