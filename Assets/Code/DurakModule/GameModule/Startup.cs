using ProjectCard.DurakModule.SettingsModule;
using ProjectCard.Shared.GameModule;
using ProjectCard.Shared.ServiceModule.SaveModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private DurakGame gameLoader;

        [SerializeField] private GameLoadProperties loadProperties;

        [SerializeField] private ScriptableSaveService[] saveServices;

        [SerializeField] DurakSettingsSaverLoader settingsLoader;


        private async void Awake()
        {
            foreach (var service in saveServices)
            {
                await service.LoadStorage();
            }

            await settingsLoader.Load();

            if (loadProperties.LoadType is GameLoadType.New)
            {
                await gameLoader.LoadNewGame();
            }
            if (loadProperties.LoadType is GameLoadType.Saved)
            {
                await gameLoader.LoadSavedGame();
            }
        }
    }
}