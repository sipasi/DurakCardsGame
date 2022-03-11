using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;

using System.Collections.Generic;

namespace Framework.Durak.Services.Movements
{
    public interface IPlayerCardMovement
    {
        UniTask MoveTo(IPlayer player, Data data);
        UniTask MoveTo(IPlayer player, IEnumerable<Data> datas);
    }
}