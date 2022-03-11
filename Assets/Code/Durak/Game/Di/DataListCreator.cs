using Framework.Durak.Datas;
using Framework.Durak.Rules.Scriptables;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Framework.Durak.Game
{
    [Serializable]
    internal class DataListCreator
    {
        [Header("Deck")]
        [SerializeField] private PlayingDeckSize size;

        public IReadOnlyList<Data> Create()
        {
            var datas = DataCreator.Create(size.Suits, size.Ranks);

            return datas;
        }
    }
}