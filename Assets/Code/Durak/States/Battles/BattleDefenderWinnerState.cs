
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Entities;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Views;

using UnityEngine;


namespace Framework.Durak.States.Battles
{
    public class BattleDefenderWinnerState : BattlePlayerWinnerState
    {
        [Header(nameof(BattleDefenderWinnerState))]
        [Header("Movement")]
        [SerializeField] private DurakCardMovementManager movement;

        [Header("Entities")]
        [SerializeField] DiscardPileEntity discardPile;

        protected override async UniTask MoveCards(IReadOnlyList<Data> datas)
        {
            await discardPile.PlaceRange(datas);

        }
        protected override void UpdatePlayerQueue(IPlayerQueueEntity entity)
        {
            var queue = entity.Value;

            entity.SetAttackerQueue(
                attacker: queue.Defender,
                defender: queue.GetNextFrom(queue.Defender));
        }
    }
}