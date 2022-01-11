
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Durak.Collections;
using Framework.Durak.Datas;

using Framework.Durak.Players;
using Framework.Durak.Services.Movements;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Durak.Entities
{
    public class Hand : MonoBehaviour, IHand
    {
        private IPlayer player;
        private Transform place;

        [SerializeField] private CardLookSide lookSide;

        [SerializeField] private CardMap map;
        [SerializeField] private DurakCardMovementManager movement;

        private void OnValidate()
        {
            foreach (var data in player.Hand)
            {
                ICard card = map.Get(data);

                card.View.LookSide = lookSide;
            }
        }

        public void Initialize(IPlayer player, Transform place)
            => (this.player, this.place) = (player, place);

        public UniTask Add(Data data)
        {
            player.Add(data);

            return movement.MoveToPlace(data, place, lookSide);
        }
        public UniTask AddRange(IEnumerable<Data> datas)
        {
            player.AddRange(datas);

            return movement.MoveToPlace(datas, place, lookSide);
        }

        public void Remove(Data data) => player.Remove(data);

        public void Clear() => player.Clear();
    }
}
