
using Cysharp.Threading.Tasks;

using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.CollectionModule;
using ProjectCard.Durak.EntityModule;
using ProjectCard.Durak.ValidatorModule;
using ProjectCard.Durak.Gameplay;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.Collections;

using UnityEngine;


namespace ProjectCard.Durak.HandlerModule
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