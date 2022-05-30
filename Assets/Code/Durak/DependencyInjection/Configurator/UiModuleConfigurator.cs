using Framework.Durak.Ui;
using Framework.Shared.Cards.Views;
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;

using System;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class UiModuleConfigurator : ServiceConfigurator
    {
        [Header("Deck")]
        [SerializeField] private Image trump;
        [SerializeField] private Image back;
        [SerializeField] private TextMeshProUGUI text;

        public override void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<IDeckView>(new DeckView(trump, back, text));
        }
    }
}
