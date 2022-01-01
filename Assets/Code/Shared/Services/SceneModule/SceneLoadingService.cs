
using System;

using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectCard.Shared.Services.SceneModule
{
    [CreateAssetMenu(fileName = "SceneLoadingService", menuName = "MyAsset/Shared/ServiceModule/SceneLoadingService")]
    public class SceneLoadingService : ScriptableObject, ISceneLoadingService
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