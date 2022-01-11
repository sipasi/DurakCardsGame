
using Framework.Durak.Collections;
using Framework.Durak.Rules.Scriptables;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Scriptables;
using Framework.Shared.Entities;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Entities
{
    public class CardListInstaller : IEntityInstaller<CardList>
    {
        [Header("Deck")]
        [SerializeField] private PlayingDeckSize size;

        [Header("Cards")]
        [SerializeField] private CardEntity prefab;
        [SerializeField] private CardTheme theme;
        [SerializeField] private Transform place;

        public void Install(CardList entity)
        {
            int total = size.Suits * size.Ranks;

            Assert.IsFalse(total == 0);

            var cards = CardEntityCreator.Create(prefab, place, theme, total);

            entity.Initialize(cards);
        }
    }
}