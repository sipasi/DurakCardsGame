using System;
using System.Collections.Generic;

using Framework.Durak.Rules;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Scriptables;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Game.EntityCreators
{
    [Serializable]
    internal class CardListCreator
    {
        [Header("Cards")]
        [SerializeField] private CardPrefab prefab;
        [SerializeField] private CardTheme theme;
        [SerializeField] private Transform place;

        public IReadOnlyList<ICard> Create(IPlayingDeckSize size)
        {
            int total = size.Total;

            Assert.IsFalse(total == 0);

            CardsBuilder.Create(out var info);

            var cards = info
                .SetPrefab(prefab)
                .SetParent(place)
                .SetOwner(new CardOwner(place))
                .SetTheme(theme)
                .SetCount(total)
                .SetNavigationFactory(static card => new TransformNavigation(card.Transform))
                .Build();

            return cards;
        }
    }
}