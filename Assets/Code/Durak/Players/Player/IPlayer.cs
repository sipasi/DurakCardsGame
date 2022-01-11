using System.Collections.Generic;

using Framework.Durak.Datas;

namespace Framework.Durak.Players
{
    public interface IPlayer : IReadonlyPlayer
    {
        void Add(Data data);
        void Remove(Data data);
        void AddRange(IEnumerable<Data> datas);
         
        void Clear();
    }
}