
using Cysharp.Threading.Tasks;

using Framework.Durak.Cards;
using Framework.Durak.Collections;
using Framework.Durak.Entities;
using Framework.Durak.Validators;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Durak.Gameplay.Handlers
{
    public abstract class CardSelectionHandlerBace : MonoBehaviour
    {
        [Header("Players")]
        [SerializeField] private PlayerQueueEntity playerQueue;

        [Header("Places")]
        [SerializeField] private BoardPlaces boardPlaces;

        [Header("Entities")]
        [SerializeField] private BoardEntity board;

        [Header("Validators")]
        [SerializeField] private SelectionValidator selectionValidator;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap entityDataMap;

        public async UniTask<bool> Handle(ICard card)
        {
            if (selectionValidator.Validate(card) is false)
            {
                return false;
            }

            Data data = entityDataMap.Get(card);

            playerQueue.Value.Current.Hand.Remove(data);

            AddDataToBoard(board.Value, data);

            await AddToBoardPlace(boardPlaces, card);

            return true;
        }

        protected abstract UniTask AddToBoardPlace(BoardPlaces places, ICard card);
        protected abstract void AddDataToBoard(IBoard<Data> board, Data data);
    }
}