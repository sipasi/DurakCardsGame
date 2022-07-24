
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    public interface ICardMovementManager
    {
        UniTask MoveToPlace(ICard card, Transform place, CardLookSide lookSide);
        UniTask MoveToPlace(IReadOnlyList<ICard> cards, Transform place, CardLookSide lookSide);
        UniTask MoveToPlace(IEnumerable<ICard> cards, Transform place, CardLookSide lookSide);
    }
}