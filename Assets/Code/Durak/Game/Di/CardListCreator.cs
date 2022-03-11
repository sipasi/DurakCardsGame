using Framework.Durak.Rules.Scriptables;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Scriptables;
using Framework.Shared.Collections;

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class CardListCreator
    {
        [Header("Deck")]
        [SerializeField] private PlayingDeckSize size;

        [Header("Cards")]
        [SerializeField] private CardEntity prefab;
        [SerializeField] private CardTheme theme;
        [SerializeField] private Transform place;

        public IReadOnlyList<ICard> Create()
        {
            int total = size.Total;

            Assert.IsFalse(total == 0);

            var cards = CardEntityCreator.Create(prefab, place, theme, total);

            return cards;
        }
    }
    [Serializable]
    internal class EntityPlaceTransformMapCreator
    {
        [SerializeField] private Transform deckPlace;
        [SerializeField] private Transform discardPilePlace;

        public IMap<EntityPlace, EntityPlaceTransformGetter> Create(IPlaces<Transform> places)
        {
            var map = new Map<EntityPlace, EntityPlaceTransformGetter>(3);

            map.Add(EntityPlace.Deck, () => deckPlace);
            map.Add(EntityPlace.Board, () => places.Place());
            map.Add(EntityPlace.DiscardPile, () => discardPilePlace);

            return map;
        }
    }
}