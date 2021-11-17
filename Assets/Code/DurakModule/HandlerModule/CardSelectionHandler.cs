
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;

using UnityEngine;


namespace ProjectCard.DurakModule.HandlerModule
{
    public class CardSelectionHandler : CardSelectionHandlerBace
    {
        protected override void AddDataToBoard(IBoard<Data> board, Data data)
        {
            board.Add(data);
        }

        protected override UniTask AddToBoardPlace(BoardPlaces places, ICard card)
        {
            return places.AddToNext(card);
        }
    }
}