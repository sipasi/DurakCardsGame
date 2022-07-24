
using System.Collections;
using System.Collections.Generic;

using Framework.Durak.Datas;

namespace Framework.Durak.Collections
{
    public class DiscardPile : IDiscardPile
    {
        private List<Data> collection = new List<Data>();

        public void Add(Data data)
        {
            collection.Add(data);
        }
        public void AddRange(IEnumerable<Data> datas)
        {
            collection.AddRange(datas);
        }

        public void Clear() => collection.Clear();

        public IEnumerator<Data> GetEnumerator() => collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => collection.GetEnumerator();
    }
}