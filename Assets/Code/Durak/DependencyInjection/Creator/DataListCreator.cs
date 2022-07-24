using System;
using System.Collections.Generic;

using Framework.Durak.Datas;
using Framework.Durak.Rules;

namespace Framework.Durak.DependencyInjection.Creators
{
    [Serializable]
    internal class DataListCreator
    {
        public IReadOnlyList<Data> Create(IPlayingDeckSize size)
        {
            var datas = DataCreator.Create(size.Suits, size.Ranks);

            return datas;
        }
    }
}