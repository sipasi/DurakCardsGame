using Framework.Shared.Scenes;
using Framework.Shared.Services.Scenes;
  
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Framework.Shared.Apps
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private SceneReference loadScreenScene;
        [SerializeField] private SceneReference mainScene;

        private async void Awake()
        {
            var loadingService = new SceneLoadingService();

            await loadingService.Load(loadScreenScene, LoadSceneMode.Additive);

            var complete = await loadingService.LoadInBackground(mainScene);

            complete.Activate();
        }
    }
}
