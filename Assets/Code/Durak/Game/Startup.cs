

using ProjectCard.Shared.Services.CollectionModule;
using ProjectCard.Shared.Services.TaskModule;

using UnityEngine;

namespace ProjectCard.Durak.GameModule
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private DurakGame gameLoader;

        [SerializeField] private TaskServiceAsync taskService;
        [SerializeField] private PoolService poolService;


        private async void Awake()
        {
            poolService.Clear();
            taskService.Clear();

            await gameLoader.LoadNewGame();
        }
    }
}