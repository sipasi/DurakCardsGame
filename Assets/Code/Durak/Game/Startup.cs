
using System.Linq;

using Framework.Durak.DependencyInjection;
using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.Game
{
    internal class Startup : MonoBehaviour
    {
        [SerializeField] private DiContainerHolder holder;
        [SerializeField] private DiContainerBuilder builder;

        [SerializeField] private DurakGame game;

        private async void Start()
        {
            IDiContainer container = holder.Container = builder.Build();

            var collection = FindObjectsOfType<MonoBehaviour>().OfType<IInitializable>();

            foreach (var item in collection)
            {
                item.Initialize(container);
            }

            await game.LoadNewGame();
        }

        private async void OnDestroy()
        {
            await game.UnloadGame();
        }
    }
}