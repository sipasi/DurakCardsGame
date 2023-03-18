using System;

using Framework.Durak.Rules;
using Framework.Durak.Rules.Scriptables;
using Framework.Shared.DependencyInjection;

using UnityEngine;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class RulesModuleConfigurator : MonoBehaviour, IConfigurator
    {
        [SerializeField] private DurakRules rules;
        [SerializeField] private PlayingDeckSize size;

        public void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<IDurakRules>(rules)
                .Add<IPlayingDeckSize>(size);
        }
    }
}