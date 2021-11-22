using ProjectCard.Shared.ServiceModule.SceneModule;

using UnityEngine;

namespace ProjectCard.Shared.SceneModule
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private SceneLoadingService sceneLoadingService;
        [SerializeField] private SceneReference loadScreenScene;
        [SerializeField] private SceneReference scene;

        public async void Load()
        {
            await sceneLoadingService.Load(loadScreenScene);

            var complete = await sceneLoadingService.LoadInBackground(scene);

            complete.Activate();
        }
    }
}
