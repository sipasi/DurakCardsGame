
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.CollectionModule;
using ProjectCard.DurakModule.GameModule;
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.DurakModule.ValidatorModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.ServiceModule.MovementModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;


namespace ProjectCard.DurakModule.HandlerModule
{
    public class CardSelectionHandler : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private CardMovementManager movement;

        [Header("Players")]
        [SerializeField] private PlayerQueue playerQueue;

        [Header("Places")]
        [SerializeField] private BoardPlaces boardPlaces;

        [Header("Shared")]
        [SerializeField] private SharedEntities shared;

        [Header("Validators")]
        [SerializeField] private SelectionValidator playerSelectionValidator;

        [Header("Collections")]
        [SerializeField] private CardEntityDataMap entityDataMap;


        public async UniTask<bool> Handle(ICard card)
        {
            Board<Data> board = shared.Board;

            if (playerSelectionValidator.Validate(card) is false)
            {
                return false;
            }

            var boardPlace = boardPlaces.Current;

            Transform place = board.IsAttacksPlace
                ? boardPlace.Attacker
                : boardPlace.Defender;

            if (board.IsDefendsPlace)
            {
                boardPlaces.Next();
            }

            Data data = entityDataMap.Get(card);

            playerQueue.Current.Hand.Remove(card);

            board.Add(data);

            playerQueue.SwitchActionType();

            await movement.MoveToPlace(card, place, CardLookSide.Face);

            return true;
        }
    }
}