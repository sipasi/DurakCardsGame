using System;
using System.Collections.Generic;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

using UnityEngine.Assertions;

namespace Framework.Durak.DependencyInjection.Creators
{
    [Serializable]
    internal class CardMapCreator
    {
        public IMap<ICard, Data> Create(IReadOnlyList<ICard> cards, IReadOnlyList<Data> datas)
        {
            Assert.AreEqual(datas.Count, cards.Count);

            return new Map<ICard, Data>(cards, datas);
        }
    }
}