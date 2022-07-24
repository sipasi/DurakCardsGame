using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;

using UnityEngine;

namespace Framework.Shared.Cards.Input
{
    internal class InputModuleConfigurator : ServiceConfigurator
    {
        [SerializeField] private CardInputInteractions interactions;

        public override void Configure(ServiceBuilder builder)
        {
            builder.singleton.Add<ICardInputInteractions>(interactions);
        }
    }
}