
using System;
using System.Linq;

using Framework.Durak.Saves;
using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.Game.DependencyInjection
{
    public static class DiContainerConfigurator
    {
        public static IDiContainer BuildForNewGame()
        {
            var (builder, behaviours) = BuildBase();

            var configurators = behaviours.OfType<INewGameConfigurator>();

            foreach (var configurator in configurators)
            {
                configurator.Configure(builder);
            }

            return builder.Build();
        }
        public static IDiContainer BuildForSavedGame(SaveData data)
        {
            var (builder, behaviours) = BuildBase();

            var configurators = behaviours.OfType<ISavedGameConfigurator>();

            foreach (var configurator in configurators)
            {
                configurator.Configure(builder, data);
            }

            return builder.Build();
        }

        private static (ServiceBuilder builder, MonoBehaviour[] behaviours) BuildBase()
        {
            var builder = new ServiceBuilder();

            var behaviours = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>();

            var identicals = behaviours.OfType<IIdenticalGameConfigurator>();

            foreach (var configurator in identicals)
            {
                configurator.Configure(builder);
            }

            return (builder, behaviours);
        }
    }
    public static class DiContainerInitializator
    {
        public static IDiContainer BuildForNewGame()
        {
            var (builder, behaviours) = BuildBase();

            var configurators = behaviours.OfType<INewGameConfigurator>();

            foreach (var configurator in configurators)
            {
                configurator.Configure(builder);
            }

            return builder.Build();
        }
        public static IDiContainer BuildForSavedGame(SaveData data)
        {
            var (builder, behaviours) = BuildBase();

            var configurators = behaviours.OfType<ISavedGameConfigurator>();

            foreach (var configurator in configurators)
            {
                configurator.Configure(builder, data);
            }

            return builder.Build();
        }

        private static (ServiceBuilder builder, MonoBehaviour[] behaviours) BuildBase()
        {
            var builder = new ServiceBuilder();

            var behaviours = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>();

            var identicals = behaviours.OfType<IIdenticalGameConfigurator>();

            foreach (var configurator in identicals)
            {
                configurator.Configure(builder);
            }

            return (builder, behaviours);
        }
    }


}