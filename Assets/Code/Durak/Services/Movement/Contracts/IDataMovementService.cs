using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    public interface IDataMovementService
    {
        UniTask MoveToPlace(Data data, Transform place, CardLookSide lookSide);
        UniTask MoveToPlace(IReadOnlyList<Data> datas, Transform place, CardLookSide lookSide);
        UniTask MoveToPlace(IEnumerable<Data> datas, Transform place, CardLookSide lookSide);
    }
}