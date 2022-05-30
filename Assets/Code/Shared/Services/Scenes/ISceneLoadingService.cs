
using Cysharp.Threading.Tasks;

using Framework.Shared.Scenes;

using UnityEngine.SceneManagement;

namespace Framework.Shared.Services.Scenes
{
    public interface ISceneLoadingService
    {
        UniTask Load(SceneReference scene, LoadSceneMode mode = LoadSceneMode.Single);
        UniTask<BackgroundLoading.Complete> LoadInBackground(SceneReference scene, LoadSceneMode mode = LoadSceneMode.Single);
    }
}
