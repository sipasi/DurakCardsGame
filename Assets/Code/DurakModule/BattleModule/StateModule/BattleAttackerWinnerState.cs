
using ProjectCard.DurakModule.CardModule;
using System.Collections.Generic;

using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;
using ProjectCard.Shared.ServiceModule.MovementModule;
using Cysharp.Threading.Tasks;

namespace ProjectCard.DurakModule.BattleModule.StateModule
{
    public sealed class BattleAttackerWinnerState : BattlePlayerWinnerState
    {
        [Header(nameof(BattleAttackerWinnerState))]
        [Header("Movement")]
        [SerializeField] private CardMovementManager movement;

        [Header("Players")]
        [SerializeField] private PlayerQueueEntity queue;
        [SerializeField] private PlayerPlaceList playerPlaceList;

        protected override async UniTask MoveCards(IReadOnlyList<Data> datas)
        {
            IPlayer defender = queue.Entity.Defender;
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