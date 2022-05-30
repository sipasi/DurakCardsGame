using UnityEngine;

namespace Framework.Shared.DependencyInjection.Unity
{
    public abstract class ServiceConfigurator : MonoBehaviour, IConfigurator
    {
        public abstract void Configure(ServiceBuilder builder);
    }
}
