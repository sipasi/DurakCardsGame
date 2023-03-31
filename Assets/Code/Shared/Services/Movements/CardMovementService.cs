using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Shared.Cards.Entities;
using Framework.Shared.Services.Pools;
using Framework.Shared.Services.Tasks;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    public delegate void CardMovementNotifyHandler();

    public class CardMovementService : ICardMovementService
    {
        private readonly Preparation preparation = new Preparation();

        private readonly ITaskServiceAsync task;
        private readonly IPoolService pool;

        public event CardMovementNotifyHandler Begin;
        public event CardMovementNotifyHandler End;

        public CardMovementService(ITaskServiceAsync task, IPoolService pool)
        {
            this.task = task;
            this.pool = pool;
        }

        public async UniTask MoveToParent(ICard temporary, ICard entity, ICardOwner owner, float speed)
        {
            preparation.BeforeMovement(temporary, entity, owner);

            await MoveTemporaryTo(temporary, entity, speed);

            preparation.AfterMovement(temporary, entity);
        }

        public async UniTask MoveToParent(ICard temporary, IReadOnlyList<ICard> entities, ICardOwner owner, float speed)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                ICard entity = entities[i];

                await MoveToParent(temporary, entity, owner, speed);
            }
        }

        private async UniTask MoveTemporaryTo(ICard temporary, ICard card, float speed)
        {
            IProcess process = GetProcess(temporary.Navigation, card.Navigation, speed);

            task.Add(process);

            Begin?.Invoke();

            await task.Wait(process);

            End?.Invoke();

            pool.Return(process);
        }

        public void Teleport(ICard temporary, ICard entity, ICardOwner owner)
        {
            preparation.BeforeMovement(temporary, entity, owner);

            preparation.AfterMovement(temporary, entity);
        }

        private IProcess GetProcess(ICardNavigation temporary, ICardNavigation card, float speed)
        {
            MoveProcess process = pool.Get<MoveProcess>();

            process.Set(temporary, card, speed);

            return process;
        }
    }
}