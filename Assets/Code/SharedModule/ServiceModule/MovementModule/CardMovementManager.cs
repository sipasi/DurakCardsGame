
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.ScriptableModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.MovementModule
{
    public class CardMovementManager : MonoBehaviour
    {
        [SerializeField] private CardEntity temporary;

        [SerializeField] private CardMovementService movement;
        [SerializeField] private SpeedVariables animationsSpeed;

        [SerializeField] private CardEntityDataMap entityDataMap;

        public async UniTask MoveToPlace(ICard card, Transform place, CardLookSide lookSide)
        {
            await movement.MoveToParent(temporary, card, place, animationsSpeed.CardMovement);

            card.View.LookSide = lookSide;
        }
        public async UniTask MoveToPlace(Data data, Transform place, CardLookSide lookSide)
        {
            ICard card = entityDataMap.Get(data);

            await movement.MoveToParent(temporary, card, place, animationsSpeed.CardMovement);

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
        public async UniTask MoveToPlace(IReadOnlyList<Data> datas, Transform place, CardLookSide lookSide)
        {
            for (int i = 0; i < datas.Count; i++)
            {
                Data data = datas[i];

                await MoveToPlace(data, place, lookSide);
            }
        }

        public async UniTask MoveToPlace(IEnumerable<ICard> cards, Transform place, CardLookSide lookSide)
        {
            foreach (var card in cards)
            {
                await MoveToPlace(card, place, lookSide);

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