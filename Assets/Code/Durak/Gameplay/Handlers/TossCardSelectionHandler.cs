
using Cysharp.Threading.Tasks;

using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.Gameplay;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.Collections;


namespace ProjectCard.Durak.HandlerModule
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