
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;


namespace ProjectCard.DurakModule.BattleModule.StateModule
{
    public class BattleDefenderWinnerState : BattlePlayerWinnerState
    {
        [Header(nameof(BattleDefenderWinnerState))]
        [Header("Movement")]
        [SerializeField] private CardMovementManager movement;

        [Header("Entities")]
        [SerializeField] TrashEntity trash;

        [Header("Places")]
        [SerializeField] private Transform trashPlace;

        protected override async UniTask MoveCards(IReadOnlyList<Data> datas)
        {
            trash.Value.AddRange(datas);

            await movement.MoveToPlace(datas, trashPlace, CardLookSide.Back);

        }
        protected override void UpdatePlayerQueue(IPlayerQueue playerQueue)
        {
            playerQueue.Set(
                attacker: playerQueue.Defender,
                defender: playerQueue.GetNextFrom(playerQueue.Defender),
                action: PlayerActionType.Attack);
        }
    }
}