using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Shared.Cards.Entities;
using Framework.Shared.Events;
using Framework.Shared.Services.Pools;
using Framework.Shared.Services.Tasks;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    [CreateAssetMenu(fileName = "CardMovementService", menuName = "MyAsset/Shared/ServiceModule/CardMovementService")]
    public class CardMovementService : Service
    {
        private readonly Preparation preparation = new Preparation();

        [Header("Services")]
        [SerializeField] private TaskServiceAsync task;
        [SerializeField] private PoolService pool;

        [Header("Move Events")]
        [SerializeField] private ScriptableAction Begin;
        [SerializeField] private ScriptableAction End;

        public async UniTask MoveToParent(ICard temporary, ICard entity, Transform parent, float speed)
        {
            preparation.BeforeMovement(temporary, entity, parent);

            await MoveTemporaryTo(temporary, entity, speed);

            preparation.AfterMovement(temporary, entity);
        }

        public async UniTask MoveToParent(ICard temporary, IReadOnlyList<ICard> entities, Transform parent, float speed)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                ICard entity = entities[i];

                await MoveToParent(temporary, entity, parent, speed);
            }
        }

        private async UniTask MoveTemporaryTo(ICard temporary, ICard card, float speed)
        {
            IProcess process = GetProcess(temporary.Transform, card.Transform, speed);

            task.Add(process);

            Begin.Rise();

            await task.Wait(process);

            End.Rise();

            pool.Return(process);
        }

        private IProcess GetProcess(Transform temporary, Transform card, float speed)
        {
            MoveProcess process = pool.Get<MoveProcess>();

            process.Set(temporary, card, speed);

            return process;
        }
    }
}