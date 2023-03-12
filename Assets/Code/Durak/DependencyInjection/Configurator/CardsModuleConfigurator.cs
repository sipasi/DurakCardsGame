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
        [Header("Temporary card")]
        [SerializeField] private CardPrefab prefab;
        [SerializeField] private Transform place;

        public override void Configure(ServiceBuilder builder)
        {
            var instance = Instantiate(prefab, place);

            CardView view = new(instance.Image, face: null, back: null);

            TemporaryCard card = new TemporaryCard(view, new TransformNavigation(instance.transform));

            builder.singleton.Add<TemporaryCard>(card);
        }
    }
}