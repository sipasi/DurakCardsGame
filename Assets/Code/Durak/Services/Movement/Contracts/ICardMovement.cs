using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;

using System.Collections.Generic;

namespace Framework.Durak.Services.Movements
{
    public interface ICardMovement
    {
        UniTask MoveTo(Data data);
        UniTask MoveTo(IEnumerable<Data> datas);
    }
}