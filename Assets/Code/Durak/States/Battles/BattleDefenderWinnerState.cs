
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
    public class BattleDefenderWinnerState : BattlePlayerWinnerState
    {
        [Header(nameof(BattleDefenderWinnerState))]
        [Header("Movement")]
        [SerializeField] private DurakCardMovementManager movement;

        [Header("Entities")]
        [SerializeField] DiscardPileEntity discardPile;

        [Header("Places")]
        [SerializeField] private Transform trashPlace;

        protected override async UniTask MoveCards(IReadOnlyList<Data> datas)
        {
            discardPile.Value.AddRange(datas);

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