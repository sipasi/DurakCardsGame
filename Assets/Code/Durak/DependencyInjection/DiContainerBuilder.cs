
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;

using System;

using UnityEngine;

namespace Framework.Durak.DependencyInjection
{
    [Serializable]
    public class DiContainerBuilder : MonoBehaviour
    {
        public IDiContainer Build()
        {
            var builder = new ServiceBuilder();

            IConfigurator[] configurators = FindObjectsOfType<ServiceConfigurator>();

            foreach (var configurator in configurators)
            {
                configurator.Configure(builder);
            }

            return builder.Build();
        }
    }
}