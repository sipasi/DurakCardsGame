using Framework.Shared.Services.Scenes;

using UnityEngine;

namespace Framework.Shared.Scenes
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