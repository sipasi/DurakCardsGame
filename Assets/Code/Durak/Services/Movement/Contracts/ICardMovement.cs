using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;

namespace Framework.Durak.Services.Movements
{
    public interface ICardMovement
    {
        UniTask MoveTo(Data data);
        UniTask MoveTo(IEnumerable<Data> datas);

        void Teleport(Data data);
        void Teleport(IEnumerable<Data> datas);
    }
}