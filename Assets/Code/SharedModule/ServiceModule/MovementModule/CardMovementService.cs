using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;
using ProjectCard.Shared.ServiceModule.CollectionModule;
using ProjectCard.Shared.ServiceModule.TaskModule;

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.MovementModule
{
    [CreateAssetMenu(fileName = "CardMovementService", menuName = "MyAsset/Shared/ServiceModule/CardMovementService")]
    public class CardMovementService : ScriptableObject
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
            preparation.BeforeMovement(entity, temporary, parent);

            await MoveTemporaryTo(entity, temporary, speed);

            preparation.AfterMovement(entity, temporary);
        }

        public async UniTask MoveToParent(ICard temporary, IReadOnlyList<ICard> entities, Transform parent, float speed)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                ICard entity = entities[i];
                await MoveToParent(temporary, entity, parent, speed);
            }
        }

        private async UniTask MoveTemporaryTo(ICard card, ICard temporary, float speed)
        {
            MoveProcess moveProcess = pool.Get<MoveProcess>();

            moveProcess.Set(temporary.Transform, card.Transform, speed);

            task.Add(moveProcess);

            Begin.Rise();

            await task.Wait(moveProcess);

            End.Rise();

            pool.Return(moveProcess);
        }
    }
}