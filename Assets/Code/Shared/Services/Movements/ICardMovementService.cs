using Cysharp.Threading.Tasks;

using Framework.Shared.Cards.Entities;

using System.Collections.Generic;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    public interface ICardMovementService
    {
        event CardMovementNotifyHandler Begin;
        event CardMovementNotifyHandler End;

        UniTask MoveToParent(ICard temporary, ICard entity, Transform parent, float speed);

        UniTask MoveToParent(ICard temporary, IReadOnlyList<ICard> entities, Transform parent, float speed);
    }
}