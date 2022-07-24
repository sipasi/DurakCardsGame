using Framework.Shared.Services.Scenes;

using UnityEngine;

namespace Framework.Shared.Apps
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private SceneLoader mainMenu;

        private async void Awake()
        {
            await mainMenu.Load();
        }
    }
}
