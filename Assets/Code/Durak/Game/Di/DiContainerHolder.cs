using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.Game
{
    internal class DiContainerHolder : MonoBehaviour
    {
        public IDiContainer Container { get; set; }
    }
}