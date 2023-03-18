using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    internal class DurakMovementsConfigurator : MonoBehaviour, IConfigurator
    {
        public void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<IDataMovementService, DataMovementService>()
                .Add<IDeckCardMovement, DeckCardMovement>()
                .Add<IBoardCardMovement, BoardCardMovement>()
                .Add<IDiscardPileCardMovement, DiscardPileCardMovement>()
                .Add<IPlayerCardMovement, PlayerCardMovement>();
        }
    }
}