using Framework.Durak.Datas;
using Framework.Durak.Rules.Scriptables;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class CardMapCreator
    {
        [SerializeField] private PlayingDeckSize size;

        public IMap<ICard, Data> Create(IReadOnlyList<ICard> cards, IReadOnlyList<Data> datas)
        {
            Assert.AreEqual(datas.Count, size.Total);
            Assert.AreEqual(cards.Count, size.Total);

            return new Map<ICard, Data>(cards, datas);
        }
    }
}