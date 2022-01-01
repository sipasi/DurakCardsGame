using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.CollectionModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.Services.Movement;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.Durak.ServiceModule.MovementModule
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