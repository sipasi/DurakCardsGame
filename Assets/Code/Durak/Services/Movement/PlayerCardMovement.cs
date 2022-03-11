using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

using System.Collections.Generic;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    public sealed class PlayerCardMovement : IPlayerCardMovement
    {
        private readonly IDataMovementManager movement;

        private readonly IMap<IPlayer, Transform> map;

        public PlayerCardMovement(IDataMovementManager movement, IMap<IPlayer, Transform> map)
        {
            this.movement = movement;
            this.map = map;
        }

        public UniTask MoveTo(IPlayer player, Data data)
        {
            var target = map.Get(player);

            return movement.MoveToPlace(data, target, player.Hand.LookSide);
        }

        public UniTask MoveTo(IPlayer player, IEnumerable<Data> datas)
        {
            var target = map.Get(player);

            return movement.MoveToPlace(datas, target, player.Hand.LookSide);
        }
    }
}