
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Cards;
using Framework.Durak.Entities;
using Framework.Durak.Players;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Views;

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
        [SerializeField] private PlayerPlaceList playerPlaceList;

        protected override async UniTask MoveCards(IReadOnlyList<Data> datas)
        {
            IPlayer defender = queue.Value.Defender;
            PlayerPosition position = defender.Position;
            List<Data> hand = defender.Hand;
            CardLookSide lookSide = defender.LookSide;

            Transform place = playerPlaceList.Get(position).Transform;

            hand.AddRange(datas);

            await movement.MoveToPlace(datas, place, lookSide);
        }

        protected override void UpdatePlayerQueue(IPlayerQueue playerQueue)
        {
            playerQueue.Set(
                attacker: playerQueue.GetNextFrom(playerQueue.Defender),
                defender: playerQueue.GetNextFrom(playerQueue.Defender, andSkip: 1),
                action: PlayerActionType.Attack);
        }
    }
}