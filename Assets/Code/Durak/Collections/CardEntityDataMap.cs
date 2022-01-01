
using ProjectCard.Durak.CardModule;
using ProjectCard.Shared.CardModule; 
using ProjectCard.Shared.Collections;

using UnityEngine;

namespace ProjectCard.Durak.CollectionModule
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