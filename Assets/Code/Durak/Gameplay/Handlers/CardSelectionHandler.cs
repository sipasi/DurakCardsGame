
using Cysharp.Threading.Tasks;

using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Durak.Services.Movements;
using Framework.Durak.Validators;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;


namespace Framework.Durak.Gameplay.Handlers
{
    public abstract class CardSelectionHandler : ICardSelectionHandler
    {
        private readonly IBoard<Data> board;
        private readonly IMap<ICard, Data> map;

        private readonly IPlayerQueue<IPlayer> queue;

        private readonly IValidator<ICard> validator;

        private readonly IBoardCardMovement movement;

        protected CardSelectionHandler(IBoard<Data> board, IMap<ICard, Data> map, IPlayerQueue<IPlayer> queue, IValidator<ICard> validator, IBoardCardMovement movement)
        {
            this.board = board;
            this.map = map;
            this.queue = queue;
            this.validator = validator;
            this.movement = movement;
        }

        public async UniTask<bool> Handle(ICard card)
        {
            if (validator.Validate(card) is false)
            {
                return false;
            }

            Data data = map.Get(card);

            queue.Current.Hand.Remove(data);

            await movement.MoveTo(data);

            AddDataToBoard(board, data);

            return true;
        }

        protected abstract void AddDataToBoard(IBoard<Data> board, Data data);
    }
}