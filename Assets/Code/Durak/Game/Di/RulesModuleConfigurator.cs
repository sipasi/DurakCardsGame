using Framework.Durak.Rules;
using Framework.Durak.Rules.Scriptables;
using Framework.Shared.DependencyInjection;

using System;

using UnityEngine;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class RulesModuleConfigurator
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