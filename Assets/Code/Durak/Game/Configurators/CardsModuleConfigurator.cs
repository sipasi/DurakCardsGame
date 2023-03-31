using System;

using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.Game.Configurators
{
    [Serializable]
    internal class CardsModuleConfigurator : MonoBehaviour, IIdenticalGameConfigurator
    {
        [Header("Temporary card")]
        [SerializeField] private CardPrefab prefab;
        [SerializeField] private Transform place;

        public void Configure(ServiceBuilder builder)
        {
            var instance = Instantiate(prefab, place);

            CardView view = new(instance.Image, face: null, back: null);

            TemporaryCard card = new TemporaryCard(view, new TransformNavigation(instance.transform));

            builder.singleton.Add<TemporaryCard>(card);
        }
    }
}