using System;
using System.Collections.Generic;

using Framework.Durak.Rules;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Scriptables;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.DependencyInjection.Creators
{
    [Serializable]
    internal class CardListCreator
    {
        [Header("Cards")]
        [SerializeField] private CardEntity prefab;
        [SerializeField] private CardTheme theme;
        [SerializeField] private Transform place;

        public IReadOnlyList<ICard> Create(IPlayingDeckSize size)
        {
            int total = size.Total;

            Assert.IsFalse(total == 0);

            var cards = CardEntityCreator.Create(prefab, place, theme, total);

            return cards;
        }
    }
}