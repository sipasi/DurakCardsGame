
using Cysharp.Threading.Tasks;

using System;

using UnityEngine.SceneManagement;

namespace Framework.Shared.Services.Scenes
{
    public class SceneLoadingService : ISceneLoadingService
    {
        public UniTask Load(int index, LoadSceneMode mode = LoadSceneMode.Single, IProgress<float> progress = null)
        {
            var operation = SceneManager.LoadSceneAsync(sceneBuildIndex: index, mode);

            return operation.ToUniTask(progress);
        }

        public UniTask Load(string name, LoadSceneMode mode = LoadSceneMode.Single, IProgress<float> progress = null)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName: name, mode);

            return operation.ToUniTask(progress);
        }

        public async UniTask<BackgroundLoading.Complete> LoadInBackground(string name, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var background = new BackgroundLoading(name, mode);

            var complete = await background.Load();

            return complete;
        }
    }
}