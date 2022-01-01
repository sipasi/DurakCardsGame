
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.EntityModule;
using ProjectCard.Durak.PlayerModule;
using ProjectCard.Durak.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.Durak.StateModule.BattleModule
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