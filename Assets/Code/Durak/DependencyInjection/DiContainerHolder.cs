using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.DependencyInjection
{
    public class DiContainerHolder : MonoBehaviour
    {
        public IDiContainer Container { get; set; }
    }
}