using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Shared.Collections
{
    public class MapMono<T1, T2> : MonoBehaviour
    {
        private Map<T1, T2> map;

        public void Initialize(IReadOnlyList<T1> cards, IReadOnlyList<T2> datas)
        {
            Assert.AreEqual(cards.Count, datas.Count);

            map = new Map<T1, T2>(cards, datas);
        }

        public T2 Get(T1 card) => map.Forward[card];
        public T1 Get(T2 data) => map.Reverse[data];
    }
}