
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.ValidatorModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;


namespace ProjectCard.DurakModule.HandlerModule
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
        [SerializeField] private SelectionValidator playerSelectionValidator;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap entityDataMap;

        public async UniTask<bool> Handle(ICard card)
        {
            if (playerSelectionValidator.Validate(card) is false)
            {
                return false;
            } 

            Data data = entityDataMap.Get(card);

            playerQueue.Entity.Current.Hand.Remove(data);

            AddDataToBoard(board.Entity, data);

            await AddToBoardPlace(boardPlaces, card);

            return true;
        }

        protected abstract UniTask AddToBoardPlace(BoardPlaces places, ICard card);
        protected abstract void AddDataToBoard(IBoard<Data> board, Data data);
    }
}