using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;
using Framework.Shared.Services.Movements;

namespace Framework.Durak.Services.Movements
{
    public sealed class DataMovementService : IDataMovementService
    {
        private readonly IMap<ICard, Data> map;
        private readonly ICardMovementManager movement;

        public DataMovementService(IMap<ICard, Data> map, ICardMovementManager movement)
        {
            this.map = map;
            this.movement = movement;
        }

        public async UniTask MoveToPlace(Data data, ICardOwner place, CardLookSide lookSide)
        {
            ICard card = map.Get(data);

            await movement.MoveToPlace(card, place, lookSide);

            card.View.LookSide = lookSide;
        }
        public async UniTask MoveToPlace(IEnumerable<Data> datas, ICardOwner place, CardLookSide lookSide)
        {
            foreach (var data in datas)
            {
                await MoveToPlace(data, place, lookSide);
            }
        }

        public void Teleport(Data data, ICardOwner place, CardLookSide lookSide)
        {
            ICard card = map.Get(data);

            movement.Teleport(card, place, lookSide);

            card.View.LookSide = lookSide;
        }

        public void Teleport(IEnumerable<Data> datas, ICardOwner place, CardLookSide lookSide)
        {
            foreach (var data in datas)
            {
                Teleport(data, place, lookSide);
            }
        }
    }
}