using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;
using Framework.Shared.Services.Movements;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    internal sealed class DataMovementService : IDataMovementService
    {
        private readonly IMap<ICard, Data> map;
        private readonly ICardMovementManager movement;

        public DataMovementService(IMap<ICard, Data> map, ICardMovementManager movement)
        {
            this.map = map;
            this.movement = movement;
        }

        public async UniTask MoveToPlace(Data data, Transform place, CardLookSide lookSide)
        {
            ICard card = map.Get(data);

            await movement.MoveToPlace(card, place, lookSide);

            card.View.LookSide = lookSide;
        }
        public async UniTask MoveToPlace(IReadOnlyList<Data> datas, Transform place, CardLookSide lookSide)
        {
            for (int i = 0; i < datas.Count; i++)
            {
                Data data = datas[i];

                await MoveToPlace(data, place, lookSide);
            }
        }
        public async UniTask MoveToPlace(IEnumerable<Data> datas, Transform place, CardLookSide lookSide)
        {
            foreach (var data in datas)
            {
                await MoveToPlace(data, place, lookSide);
            }
        }
    }
}