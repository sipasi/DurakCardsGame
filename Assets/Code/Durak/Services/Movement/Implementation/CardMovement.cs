using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Views;

using System.Collections.Generic;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    internal abstract class CardMovement : ICardMovement
    {
        private readonly CardLookSide lookSide;

        private readonly IDataMovementService movement;

        protected CardMovement(IDataMovementService movement, CardLookSide lookSide)
        {
            this.lookSide = lookSide;
            this.movement = movement;
        }

        public UniTask MoveTo(Data data)
        {
            Transform target = GetTarget();

            return movement.MoveToPlace(data, target, lookSide);
        }

        public UniTask MoveTo(IEnumerable<Data> datas)
        {
            Transform target = GetTarget();

            return movement.MoveToPlace(datas, target, lookSide);
        }

        protected abstract Transform GetTarget();
    }
}