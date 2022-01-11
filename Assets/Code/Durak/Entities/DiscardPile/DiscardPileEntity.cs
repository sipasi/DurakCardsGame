using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class DiscardPileEntity : MonoBehaviour, IDiscardPileEntity
    {
        private List<Data> datas;
        private Transform place;

        [SerializeField] private DurakCardMovementManager movement;

        public IReadOnlyList<Data> Value => datas;

        public void Initialize(List<Data> datas, Transform place) => (this.datas, this.place) = (datas, place);

        public UniTask Place(Data data)
        {
            return movement.MoveToPlace(data, place, CardLookSide.Back);
        }
        public UniTask PlaceRange(IEnumerable<Data> datas)
        {
            return movement.MoveToPlace(datas, place, CardLookSide.Back);
        }
    }
}