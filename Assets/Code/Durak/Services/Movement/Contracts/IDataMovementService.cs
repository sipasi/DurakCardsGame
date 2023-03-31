using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    public interface IDataMovementService
    {
        UniTask MoveToPlace(Data data, ICardOwner place, CardLookSide lookSide); 
        UniTask MoveToPlace(IEnumerable<Data> datas, ICardOwner place, CardLookSide lookSide);

        void Teleport(Data data, ICardOwner place, CardLookSide lookSide);
        void Teleport(IEnumerable<Data> datas, ICardOwner place, CardLookSide lookSide);
    }
}