
using ProjectCard.DurakModule.CardModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;

using UnityEngine;

namespace ProjectCard.DurakModule.CollectionModule
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