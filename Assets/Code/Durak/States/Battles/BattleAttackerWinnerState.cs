
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Entities;
using Framework.Durak.Services.Movements;

using UnityEngine;

namespace Framework.Durak.States.Battles
{
    public sealed class BattleAttackerWinnerState : BattlePlayerWinnerState
    {
        [Header(nameof(BattleAttackerWinnerState))]
        [Header("Movement")]
        [SerializeField] private DurakCardMovementManager movement;

        [Header("Players")]
        [SerializeField] private PlayerQueueEntity queue;

        protected override async UniTask MoveCards(IReadOnlyList<Data> datas)
        {
            IPlaye defender = queue.Value.Defender;

            await defender.AddRange(datas);
        }

        protected override void UpdatePlayerQueue(IPlayerQueueEntity entity)
        {
            var queue = entity.Value;

            entity.SetAttackerQueue(
                attacker: queue.GetNextFrom(queue.Defender),
                defender: queue.GetNextFrom(queue.Defender, andSkip: 1));
        }
    }
}