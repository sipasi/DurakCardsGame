
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    public class CardMovementManager : MonoBehaviour
    {
        [SerializeField] private CardEntity temporary;

        [SerializeField] private CardMovementService movement;

        [SerializeField, Range(0.1f, 5)] private float speed;

        public async UniTask MoveToPlace(ICard card, Transform place, CardLookSide lookSide)
        {
            await movement.MoveToParent(temporary, card, place, speed);

            card.View.LookSide = lookSide;
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