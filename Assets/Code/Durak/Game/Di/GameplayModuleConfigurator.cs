using Framework.Durak.Gameplay;
using Framework.Durak.Gameplay.Handlers;
using Framework.Durak.Validators;
using Framework.Shared.DependencyInjection;

using System;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class GameplayModuleConfigurator
    {
        public void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<IAttackerSelectionHandler, AttackerSelectionHandler>()
                .Add<IDefenderSelectionHandler, DefenderSelectionHandler>()
                .Add<IAttackerValidator, AttackerSelectionValidator>()
                .Add<IDefenderValidator, DefenderSelectionValidator>()
                .Add<ICardDealer, CardDealer>();
        }
    }
}