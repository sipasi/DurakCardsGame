using Framework.Durak.Game;
using Framework.Durak.Services.Movements;
using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.Game.Configurators
{
    internal class DurakMovementsConfigurator : MonoBehaviour, IIdenticalGameConfigurator
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