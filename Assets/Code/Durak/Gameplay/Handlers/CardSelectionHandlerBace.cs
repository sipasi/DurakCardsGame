
using Cysharp.Threading.Tasks;

using Framework.Durak.Collections;
using Framework.Durak.Datas;
using Framework.Durak.Entities;
using Framework.Durak.Validators;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Entities;

using UnityEngine;

namespace Framework.Durak.Gameplay.Handlers
{
    public abstract class CardSelectionHandlerBace : MonoBehaviour
    {
        [Header("Players")]
        [SerializeField] private PlayerQueueEntity playerQueue;

        [Header("Entities")]
        [SerializeField] private BoardEntity board;

        [Header("Validators")]
        [SerializeField] private SelectionValidator selectionValidator;

        [Header("Collections")]
        [SerializeField] private CardMap entityDataMap;

        public async UniTask<bool> Handle(ICard card)
        {
            if (selectionValidator.Validate(card) is false)
            {
                return false;
            }

            Data data = entityDataMap.Get(card);

            playerQueue.Value.Current.Remove(data);

            await AddDataToBoard(board, data);

            return true;
        }

        protected abstract UniTask AddDataToBoard(IBoardEnity<Data> board, Data data);
    }
}