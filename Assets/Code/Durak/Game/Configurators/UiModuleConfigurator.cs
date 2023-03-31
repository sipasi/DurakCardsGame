using System;

using Framework.Shared.Cards.Views;
using Framework.Shared.DependencyInjection;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Framework.Durak.Game.Configurators
{
    [Serializable]
    internal class UiModuleConfigurator : MonoBehaviour, IIdenticalGameConfigurator
    {
        [Header("Deck")]
        [SerializeField] private Image trump;
        [SerializeField] private Image back;
        [SerializeField] private TextMeshProUGUI text;

        public void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<IDeckView>(new DeckView(trump, back, text));
        }
    }
}
