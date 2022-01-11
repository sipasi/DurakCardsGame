
using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Shared.Collections;
using Framework.Shared.Entities;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Entities
{
    public class DeckEntityInstaller : IEntityInstaller<DeckEntity>
    {
        [Header("Deck")]
        [SerializeField] private Transform place;

        [Header("Collections")]
        [SerializeField] private DataList datas;
        [SerializeField] private CardList cards;

        public void Install(DeckEntity entity)
        {
            Assert.IsNotNull(datas.Values, "Can't initialize a Deck before a DataList has been initialized");
            Assert.IsNotNull(cards.Values, "Can't initialize a Deck before a CardList has been initialized");

            var deck = new Deck<Data>(datas.Values);

            entity.Initialize(deck, cards.Values, place);
        }
    }
}