using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;
using Framework.Shared.Services.Movements;

using System.Collections.Generic;

using UnityEngine;

namespace Framework.Durak.Services.Movements
{
    public delegate Transform EntityPlaceTransformGetter();

    public sealed class GlobalCardMovement : IGlobalCardMovement
    {
        private readonly ICardMovementManager cardMovement;
        private readonly IDataMovementManager dataMovement;

        private readonly IMap<EntityPlace, EntityPlaceTransformGetter> map;

        public GlobalCardMovement(ICardMovementManager cardMovement, IDataMovementManager dataMovement, IMap<EntityPlace, EntityPlaceTransformGetter> map)
        {
            this.cardMovement = cardMovement;
            this.dataMovement = dataMovement;
            this.map = map;
        }

        public UniTask MoveTo(Data data, EntityPlace place, CardLookSide lookSide)
        {
            var target = GetTransform(place);

            return dataMovement.MoveToPlace(data, target, lookSide);
        }
        public UniTask MoveTo(IEnumerable<Data> datas, EntityPlace place, CardLookSide lookSide)
        {
            var target = GetTransform(place);

            return dataMovement.MoveToPlace(datas, target, lookSide);
        }

        public UniTask MoveTo(ICard card, EntityPlace place, CardLookSide lookSide)
        {
            var target = GetTransform(place);

            return cardMovement.MoveToPlace(card, target, lookSide);
        }
        public UniTask MoveTo(IEnumerable<ICard> cards, EntityPlace place, CardLookSide lookSide)
        {
            var target = GetTransform(place);

            return cardMovement.MoveToPlace(cards, target, lookSide);
        }

        private Transform GetTransform(EntityPlace place)
        {
            EntityPlaceTransformGetter getter = map.Get(place);

            var transform = getter.Invoke();

            return transform;
        }
    }
}