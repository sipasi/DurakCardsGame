using ProjectCard.DurakModule.SettingsModule;
using ProjectCard.Shared.GameModule;
using ProjectCard.Shared.ServiceModule.CollectionModule;
using ProjectCard.Shared.ServiceModule.SaveModule;
using ProjectCard.Shared.ServiceModule.TaskModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private DurakGame gameLoader;

        [SerializeField] private GameLoadProperties loadProperties;

        [SerializeField] private DurakSettingsSaverLoader settingsLoader;

        [SerializeField] private TaskServiceAsync taskService;
        [SerializeField] private PoolService poolService;

        [SerializeField] private ScriptableSaveService[] saveServices;

        private async void Awake()
        {
            foreach (var service in saveServices)
            {
                await service.LoadStorage();
            }

            await settingsLoader.Load();

            poolService.Clear();
            taskService.Clear();

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