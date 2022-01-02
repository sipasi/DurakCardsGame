
using Framework.Durak.Cards;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Collections
{
    public class CardEntityDataMap : MonoBehaviour
    {
        private Map<ICard, Data> map;

        public void Initialize(ICard[] cards, Data[] datas)
        {
            map = new Map<ICard, Data>(cards, datas);
        }

        public Data Get(ICard card) => map.Forward[card];
        public ICard Get(Data data) => map.Reverse[data];
    }
}