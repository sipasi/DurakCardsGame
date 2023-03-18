using System;

using Framework.Durak.Gameplay;
using Framework.Durak.Gameplay.Handlers;
using Framework.Durak.Validators;
using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class GameplayModuleConfigurator : MonoBehaviour, IConfigurator
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