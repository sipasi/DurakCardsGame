using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

namespace Framework.Durak.Services.Movements
{
    public abstract class CardMovement : ICardMovement
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
            ICardOwner target = GetTarget();

            return movement.MoveToPlace(data, target, lookSide);
        }

        public UniTask MoveTo(IEnumerable<Data> datas)
        {
            ICardOwner target = GetTarget();

            return movement.MoveToPlace(datas, target, lookSide);
        }

        public void Teleport(Data data)
        {
            ICardOwner target = GetTarget();

            movement.Teleport(data, target, lookSide);
        }
        public void Teleport(IEnumerable<Data> datas)
        {
            ICardOwner target = GetTarget();

            movement.Teleport(datas, target, lookSide);
        }

        protected abstract ICardOwner GetTarget();
    }
}