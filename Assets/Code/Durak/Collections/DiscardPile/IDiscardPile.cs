
using Framework.Durak.Datas;

using System.Collections.Generic;

namespace Framework.Durak.Collections
{
    public interface IDiscardPile : IDiscardPileReference, IEnumerable<Data>
    {
        void Add(Data data);
        void AddRange(IEnumerable<Data> datas);

        void Clear();
    }
}