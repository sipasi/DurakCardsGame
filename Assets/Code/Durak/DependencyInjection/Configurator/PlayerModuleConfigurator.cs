using Framework.Durak.Players;
using Framework.Durak.Players.Selectors;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;
using Framework.Shared.Signals;

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class PlayerModuleConfigurator : ServiceConfigurator
    {
        public override void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<AiRandomAttacker>()
                .Add<AiRandomDefender>()
                .Add<RealInputCardSelector>()
                .Add<IRealInputListener, RealInputListener>()
                .Add<IAiSelectorsGroup, AiSelectorsGroup>()
                .Add<IRealInputSelectorsGroup, RealInputSelectorsGroup>()
                .Add<IReadonlyIndexer<PlayerType, ISelectorsGroup>, SelectorsIndexer>();
        }

        private class RealInputListener : IRealInputListener
        {
            public event Action<ICard> Selected;
            public event Action Passed;
        }

        private class AiSelectorsGroup : IAiSelectorsGroup
        {
            public ICardSelector Attacking { get; }
            public ICardSelector Defending { get; }

            public AiSelectorsGroup(AiRandomAttacker attacking, AiRandomDefender defending)
            {
                Attacking = attacking;
                Defending = defending;
            }
        }
        private class RealInputSelectorsGroup : IRealInputSelectorsGroup
        {
            public ICardSelector Attacking { get; }
            public ICardSelector Defending { get; }

            public RealInputSelectorsGroup(RealInputCardSelector selector)
            {
                Attacking = selector;
                Defending = selector;
            }
        }

        private class SelectorsIndexer : IReadonlyIndexer<PlayerType, ISelectorsGroup>
        {
            private readonly ISelectorsGroup[] array;

            public ISelectorsGroup this[PlayerType index]
            {
                get => array[(int)index];

                private set => array[(int)index] = value;
            }

            public int Count => array.Length;

            public SelectorsIndexer(IAiSelectorsGroup ai, IRealInputSelectorsGroup real)
            {
                array = new ISelectorsGroup[2];

                this[PlayerType.Ai] = ai;
                this[PlayerType.Real] = real;
            }

            public IEnumerator<KeyValuePair<PlayerType, ISelectorsGroup>> GetEnumerator()
            {
                static KeyValuePair<PlayerType, ISelectorsGroup> GetPair(ISelectorsGroup[] array, PlayerType type)
                    => new KeyValuePair<PlayerType, ISelectorsGroup>(type, array[(int)type]);

                yield return GetPair(array, PlayerType.Ai);
                yield return GetPair(array, PlayerType.Real);
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}