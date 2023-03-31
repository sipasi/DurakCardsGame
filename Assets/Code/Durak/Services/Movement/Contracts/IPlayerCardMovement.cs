using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;

namespace Framework.Durak.Services.Movements
{
    public interface IPlayerCardMovement
    {
        UniTask MoveTo(IPlayer player, Data data);
        UniTask MoveTo(IPlayer player, IEnumerable<Data> datas);

        void Teleport(IPlayer player, Data data);
        void Teleport(IPlayer player, IEnumerable<Data> datas);
    }
}