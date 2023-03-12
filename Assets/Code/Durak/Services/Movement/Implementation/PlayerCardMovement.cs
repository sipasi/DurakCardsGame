using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    internal sealed class PlayerCardMovement : IPlayerCardMovement
    {
        private readonly IDataMovementService movement;

        public PlayerCardMovement(IDataMovementService movement)
        {
            this.movement = movement;
        }

        public UniTask MoveTo(IPlayer player, Data data)
        {
            return movement.MoveToPlace(data, player.Owner, player.Hand.LookSide);
        }

        public UniTask MoveTo(IPlayer player, IEnumerable<Data> datas)
        {
            return movement.MoveToPlace(datas, player.Owner, player.Hand.LookSide);
        }
    }
}