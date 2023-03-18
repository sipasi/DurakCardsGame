
using System;
using System.Linq;

using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.DependencyInjection
{
    [Serializable]
    public class DiContainerBuilder : MonoBehaviour
    {
        public IDiContainer Build()
        {
            var builder = new ServiceBuilder();

            var configurators = FindObjectsOfType<MonoBehaviour>().OfType<IConfigurator>();

            foreach (var configurator in configurators)
            {
                configurator.Configure(builder);
            }

            return builder.Build();
        }
    }
}