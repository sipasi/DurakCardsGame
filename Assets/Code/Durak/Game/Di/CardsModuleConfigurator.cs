using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.DependencyInjection;

using System;

using UnityEngine;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class CardsModuleConfigurator
    {
        [SerializeField] private TemporaryCardEntity temporary;

        public void Configure(ServiceBuilder builder)
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
        }
    }
}