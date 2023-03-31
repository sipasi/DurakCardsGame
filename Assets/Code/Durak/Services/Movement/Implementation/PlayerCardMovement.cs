using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

namespace Framework.Durak.Services.Movements
{
    public sealed class PlayerCardMovement : IPlayerCardMovement
    {
        private readonly IDataMovementService movement;
        private readonly IMap<Place, ICardOwner> map;

        public PlayerCardMovement(IDataMovementService movement, IMap<Place, ICardOwner> map)
        {
            this.movement = movement;
            this.map = map;
        }

        public UniTask MoveTo(IPlayer player, Data data)
        {
            ICardOwner owner = map.Get(player.Place);

            return movement.MoveToPlace(data, owner, player.Hand.LookSide);
        }

        public UniTask MoveTo(IPlayer player, IEnumerable<Data> datas)
        {
            ICardOwner owner = map.Get(player.Place);

            return movement.MoveToPlace(datas, owner, player.Hand.LookSide);
        }

        public void Teleport(IPlayer player, Data data)
        {
            ICardOwner owner = map.Get(player.Place);

            movement.Teleport(data, owner, player.Hand.LookSide);
        }

        public void Teleport(IPlayer player, IEnumerable<Data> datas)
        {
            foreach (var data in datas)
            {
                Teleport(player, data);
            }
        }
    }
}