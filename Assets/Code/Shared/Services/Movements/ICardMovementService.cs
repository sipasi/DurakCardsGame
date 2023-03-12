using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Shared.Cards.Entities;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    public interface ICardMovementService
    {
        event CardMovementNotifyHandler Begin;
        event CardMovementNotifyHandler End;

        UniTask MoveToParent(ICard temporary, ICard entity, ICardOwner owner, float speed);

        UniTask MoveToParent(ICard temporary, IReadOnlyList<ICard> entities, ICardOwner owner, float speed);
    }
}