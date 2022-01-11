
using System;

using Cysharp.Threading.Tasks;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
using Framework.Shared.Collections;
using Framework.Shared.Entities;
using Framework.Shared.Services.Movements;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class BoardEntity : MonoBehaviour, IBoardEnity<Data>
    {
        private IBoard<Data> board;
        private IPlaces<Transform> places;

        [SerializeField] private DurakCardMovementManager movement;

        public IReadonlyBoard<Data> Value => board;

        public void Initialize(IBoard<Data> board, IPlaces<Transform> places)
            => (this.board, this.places) = (board, places);

        public async UniTask Place(Data data) => await PlaceAs(data, board.Add, places.Place);
        public async UniTask PlaceToAttacks(Data data) => await PlaceAs(data, board.AddToAttacks, places.ToAttacks);
        public async UniTask PlaceToDefends(Data data) => await PlaceAs(data, board.AddToDefends, places.ToDefends);

        private async UniTask PlaceAs(Data data, Action<Data> board, Func<Transform> places)
        {
            board.Invoke(data);
             
            var place = places.Invoke();

            await movement.MoveToPlace(data, place, CardLookSide.Face);
        }

        public void Clear()
        {
            board.Clear();
            places.Clear();
        }
    }
}