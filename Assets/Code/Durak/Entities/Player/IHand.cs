
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;

namespace Framework.Durak.Entities
{
    public interface IHand
    {
        UniTask Add(Data data);
        UniTask AddRange(IEnumerable<Data> datas);

        void Remove(Data data);

        void Clear();
    }
}
