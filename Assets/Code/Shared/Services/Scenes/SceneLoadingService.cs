
using Cysharp.Threading.Tasks;

using Framework.Shared.Scenes;

using UnityEngine.SceneManagement;

namespace Framework.Shared.Services.Scenes
{
    public class SceneLoadingService : ISceneLoadingService
    {
        public UniTask Load(SceneReference scene, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var operation = SceneManager.LoadSceneAsync(scene, mode);

            return operation.ToUniTask();
        }

        public UniTask<BackgroundLoading.Complete> LoadInBackground(SceneReference scene, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var background = new BackgroundLoading(scene, mode);

            return background.Load();
        }
    }
}