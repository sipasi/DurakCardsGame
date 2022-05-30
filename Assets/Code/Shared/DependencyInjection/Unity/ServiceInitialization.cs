using UnityEngine;

namespace Framework.Shared.DependencyInjection.Unity
{
    public abstract class ServiceInitialization : MonoBehaviour, IInitializable
    {
        public abstract void Initialize(IDiContainer container);
    }
}
