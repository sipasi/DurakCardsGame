
using Cysharp.Threading.Tasks;

using Framework.Durak.Cards;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

namespace Framework.Durak.Gameplay.Handlers
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