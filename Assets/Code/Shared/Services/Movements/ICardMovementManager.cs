
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

namespace Framework.Shared.Services.Movements
{
    public interface ICardMovementManager
    {
        UniTask MoveToPlace(ICard card, ICardOwner place, CardLookSide lookSide);
        UniTask MoveToPlace(IReadOnlyList<ICard> cards, ICardOwner place, CardLookSide lookSide);
        UniTask MoveToPlace(IEnumerable<ICard> cards, ICardOwner place, CardLookSide lookSide);
    }
}