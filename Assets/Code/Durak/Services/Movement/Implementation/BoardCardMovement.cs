using Framework.Durak.Players;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    internal sealed class BoardCardMovement : CardMovement, IBoardCardMovement
    {
        private readonly IPlayerQueue<IPlayer> queue;
        private readonly IPlaces<Transform> places;

        public BoardCardMovement(IDataMovementService movement, IPlayerQueue<IPlayer> queue, IPlaces<Transform> places)
            : base(movement, CardLookSide.Face)
        {
            this.queue = queue;
            this.places = places;
        }

        protected override Transform GetTarget()
        {
            Transform target = queue.IsAttackerQueue switch
            {
                true => places.ToAttacks(),
                false => places.ToDefends(),
            };

            return target;
        }
    }
}