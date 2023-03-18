using System;

using Framework.Shared.Cards.Views;
using Framework.Shared.DependencyInjection;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class UiModuleConfigurator : MonoBehaviour, IConfigurator
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
