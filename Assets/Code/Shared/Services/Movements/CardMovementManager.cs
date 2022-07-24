
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    public class CardMovementManager : ICardMovementManager
    {
        private readonly ICard temporary;

        private readonly ICardMovementService movement;

        private readonly MovementSpeed speed;

        public CardMovementManager(ITemporaryCard temporary, ICardMovementService movement, MovementSpeed speed)
        {
            this.temporary = temporary;
            this.movement = movement;
            this.speed = speed;
        }

        public UniTask MoveToPlace(ICard card, Transform place, CardLookSide lookSide)
        {
            card.View.LookSide = lookSide;

            return movement.MoveToParent(temporary, card, place, speed.Value);
        }
        public async UniTask MoveToPlace(IReadOnlyList<ICard> cards, Transform place, CardLookSide lookSide)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                ICard card = cards[i];

                await MoveToPlace(card, place, lookSide);
            }
        }
        public async UniTask MoveToPlace(IEnumerable<ICard> cards, Transform place, CardLookSide lookSide)
        {
            foreach (var card in cards)
            {
                await MoveToPlace(card, place, lookSide);
            }
        }
    }
}