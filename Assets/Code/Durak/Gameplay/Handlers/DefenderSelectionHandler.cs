
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.Services.Movements;
using Framework.Durak.Validators;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;


namespace Framework.Durak.Gameplay.Handlers
{
    public class DefenderSelectionHandler : CardSelectionHandler, IDefenderSelectionHandler
    {
        public DefenderSelectionHandler(IBoard<Data> board, IMap<ICard, Data> map, IPlayerQueue<IPlayer> queue, IDefenderValidator validator, IGlobalCardMovement movement)
            : base(board, map, queue, validator, movement) { }

        protected override void AddDataToBoard(IBoard<Data> board, Data data)
        {
            board.AddToDefends(data);
        }
    }
}