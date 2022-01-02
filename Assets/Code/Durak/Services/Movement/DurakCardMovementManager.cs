using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Cards;
using Framework.Durak.Collections;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Services.Movements;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    public sealed class DurakCardMovementManager : CardMovementManager
    {
        [SerializeField] private CardEntityDataMap entityDataMap;

        public async UniTask MoveToPlace(Data data, Transform place, CardLookSide lookSide)
        {
            ICard card = entityDataMap.Get(data);

            await MoveToPlace(card, place, lookSide);

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