
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.Services.Movements;
using Framework.Durak.Validators;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;


namespace Framework.Durak.Gameplay.Handlers
{
    public class AttackerSelectionHandler : CardSelectionHandler, IAttackerSelectionHandler
    {
        public AttackerSelectionHandler(IBoard<Data> board, IMap<ICard, Data> map, IPlayerQueue<IPlayer> queue, IAttackerValidator validator, IBoardCardMovement movement)
            : base(board, map, queue, validator, movement) { }

        protected override void AddDataToBoard(IBoard<Data> board, Data data)
        {
            board.AddToAttacks(data);
        }
    }
}