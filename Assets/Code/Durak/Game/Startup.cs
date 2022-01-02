

using Framework.Shared.Services.Pools;

using Framework.Shared.Services.Tasks;

using UnityEngine;

namespace Framework.Durak.Game
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