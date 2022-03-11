using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

using System.Collections.Generic;

namespace Framework.Durak.Services.Movements
{
    public interface IGlobalCardMovement
    {
        UniTask MoveTo(Data data, EntityPlace place, CardLookSide lookSide);
        UniTask MoveTo(ICard data, EntityPlace place, CardLookSide lookSide);
        UniTask MoveTo(IEnumerable<Data> data, EntityPlace place, CardLookSide lookSide);
        UniTask MoveTo(IEnumerable<ICard> data, EntityPlace place, CardLookSide lookSide);
    }
}