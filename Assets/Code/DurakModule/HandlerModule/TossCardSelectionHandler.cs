
using Cysharp.Threading.Tasks;

using ProjectCard.DurakModule.CardModule;
using ProjectCard.DurakModule.ViewModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.CollectionModule;


namespace ProjectCard.DurakModule.HandlerModule
{
    public class TossCardSelectionHandler : CardSelectionHandlerBace
    {
        protected override void AddDataToBoard(IBoard<Data> board, Data data)
        {
            board.AddToAttacks(data);
        }

        protected override UniTask AddToBoardPlace(BoardPlaces places, ICard card)
        {
            return places.AddToAttacks(card);
        }
    }
}