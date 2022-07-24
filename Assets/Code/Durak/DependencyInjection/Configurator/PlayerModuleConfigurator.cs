﻿using System;
using System.Collections;
using System.Collections.Generic;

using Framework.Durak.Players;
using Framework.Durak.Players.Selectors;
using Framework.Shared.Cards.Input;
using Framework.Shared.Collections;
using Framework.Shared.DependencyInjection;
using Framework.Shared.DependencyInjection.Unity;
using Framework.Shared.Events;

using UnityEngine;

namespace Framework.Durak.DependencyInjection.Configurators
{
    [Serializable]
    internal class PlayerModuleConfigurator : ServiceConfigurator
    {
        [SerializeField] private ScriptableAction pass;

        public override void Configure(ServiceBuilder builder)
        {
            builder.singleton
                .Add<AiRandomAttacker>()
                .Add<AiRandomDefender>()
                .Add<RealInputCardSelector>()

                .Add(new RealPlayerInteractions(pass))

                .Add<IRealInputListener, RealInputListener>()
                .Add<IAiSelectorsGroup, AiSelectorsGroup>()
                .Add<IRealInputSelectorsGroup, RealInputSelectorsGroup>()
                .Add<IReadonlyIndexer<PlayerType, ISelectorsGroup>, SelectorsIndexer>();
        }


        private sealed class RealPlayerInteractions
        {
            private readonly ScriptableAction pass;

            public RealPlayerInteractions(ScriptableAction passEvent)
            {
                this.pass = passEvent;
            }

            public event Action Passed { add => pass.Event += value; remove => pass.Event -= value; }
        }
        private sealed class RealInputListener : IRealInputListener
        {
            private readonly ICardInputInteractions interactions;
            private readonly RealPlayerInteractions realPlayerInteractions;

            public RealInputListener(ICardInputInteractions interactions, RealPlayerInteractions realPlayerInteractions)
            {
                this.interactions = interactions;
                this.realPlayerInteractions = realPlayerInteractions;
            }

            public event CardInteraction Selected { add => interactions.Selected += value; remove => interactions.Selected -= value; }
            public event Action Passed { add => realPlayerInteractions.Passed += value; remove => realPlayerInteractions.Passed -= value; }
        }

        private sealed class AiSelectorsGroup : IAiSelectorsGroup
        {
            public ICardSelector Attacking { get; }
            public ICardSelector Defending { get; }

            public AiSelectorsGroup(AiRandomAttacker attacking, AiRandomDefender defending)
            {
                Attacking = attacking;
                Defending = defending;
            }
        }
        private sealed class RealInputSelectorsGroup : IRealInputSelectorsGroup
        {
            public ICardSelector Attacking { get; }
            public ICardSelector Defending { get; }

            public RealInputSelectorsGroup(RealInputCardSelector selector)
            {
                Attacking = selector;
                Defending = selector;
            }
        }

        private sealed class SelectorsIndexer : IReadonlyIndexer<PlayerType, ISelectorsGroup>
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