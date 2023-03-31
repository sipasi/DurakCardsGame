using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    public sealed class BoardCardMovement : CardMovement, IBoardCardMovement
    {
        private readonly IDataMovementService movement;
        private readonly IPlayerQueue<IPlayer> queue;
        private readonly IPlaces<Transform> places;

        public BoardCardMovement(IDataMovementService movement, IPlayerQueue<IPlayer> queue, IPlaces<Transform> places)
            : base(movement, CardLookSide.Face)
        {
            this.movement = movement;
            this.queue = queue;
            this.places = places;
        }

        public void TeleportToAttacks(Data data)
        {
            Transform target = places.ToAttacks();

            movement.Teleport(data, new CardOwner(target), CardLookSide.Face);
        }

        public void TeleportToDefends(Data data)
        {
            Transform target = places.ToDefends();

            movement.Teleport(data, new CardOwner(target), CardLookSide.Face);
        }

        protected override ICardOwner GetTarget()
        {
            Transform target = queue.IsAttackerQueue switch
            {
                true => places.ToAttacks(),
                false => places.ToDefends(),
            };

            return new CardOwner(target);
        }
    }
}