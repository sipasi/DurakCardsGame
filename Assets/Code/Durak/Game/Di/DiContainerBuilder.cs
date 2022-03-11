
using Framework.Durak.States;
using Framework.Shared.DependencyInjection;

using System;

using UnityEngine;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class DiContainerBuilder
    {
        [SerializeField] private CollectionModuleConfigurator collectionConfigurator;
        [SerializeField] private ServiceModuleConfigurator serviceConfigurator;

        [SerializeField] private PlayerModuleConfigurator playerConfigurator;

        [SerializeField] private CardsModuleConfigurator cardsConfigurator;

        [SerializeField] private RulesModuleConfigurator rulesConfigurator;

        public IDiContainer Build()
        {
            var builder = new ServiceBuilder();

            var gameplayConfigurator = new GameplayModuleConfigurator();
            var machineConfigurator = new StateMachineConfigurator();

            gameplayConfigurator.Configure(builder);
            machineConfigurator.Configure(builder);

            collectionConfigurator.Configure(builder);

            serviceConfigurator.Configure(builder);

            playerConfigurator.Configure(builder);

            cardsConfigurator.Configure(builder);

            rulesConfigurator.Configure(builder);

            return builder.Build();
        }
    }
}