using ProjectCard.Shared.SceneModule; 
using ProjectCard.Shared.Services.SceneModule;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectCard.Shared.StartupModule
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private SceneLoadingService loadingService;
        [SerializeField] private SceneReference loadScreenScene;
        [SerializeField] private SceneReference mainScene;

        private async void Awake()
        {
            await loadingService.Load(loadScreenScene, LoadSceneMode.Additive);

            var complete = await loadingService.LoadInBackground(mainScene);

            complete.Activate();
        }
    }
}
