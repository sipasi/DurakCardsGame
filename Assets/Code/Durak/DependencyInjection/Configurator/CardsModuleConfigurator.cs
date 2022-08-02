using System;

using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;

using UnityEngine;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class CardsModuleConfigurator : ServiceConfigurator
    {
        [SerializeField] private TemporaryCardEntity temporary;

        public override void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<ITemporaryCard>(temporary);
        }

        [Serializable]
        private class TemporaryCardEntity : ITemporaryCard
        {
            [SerializeField] private CardEntity card;

            public CardView View => card.View;
            public Transform Transform => card.Transform;

            public bool InputSensitive => card.InputSensitive;
        }
    }
}