using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;

namespace Framework.Durak.Services.Movements
{
    internal class DurakMovementsConfigurator : ServiceConfigurator
    {
        public override void Configure(ServiceBuilder builder)
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