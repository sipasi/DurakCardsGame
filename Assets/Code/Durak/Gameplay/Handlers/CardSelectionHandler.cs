
using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Shared.Entities;

namespace Framework.Durak.Gameplay.Handlers
{
    public class CardSelectionHandler : CardSelectionHandlerBace
    {
        protected override UniTask AddDataToBoard(IBoardEnity<Data> board, Data data)
        {
            return board.Place(data);
        }
    }
}