using ProjectCard.Shared.GameModule;
using ProjectCard.Shared.ServiceModule.SaveModule;

using UnityEngine;

namespace ProjectCard.DurakModule.GameModule
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private ScriptableSaveService saveService;
        [SerializeField] private DurakGameLoader gameLoader;

        [SerializeField] private GameLoadProperties loadProperties;


        private async void Awake()
        {
            await saveService.LoadStorage();

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