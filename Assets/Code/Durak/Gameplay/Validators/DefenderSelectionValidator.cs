
using Framework.Durak.Datas;
using Framework.Durak.Datas.Extensions;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Validators
{
    public class DefenderSelectionValidator : IValidator<ICard>, IDefenderValidator
    {
        private readonly IDeck<Data> deck;
        private readonly IBoard<Data> board;
        private readonly IMap<ICard, Data> map;
        private readonly IPlayerQueue<IPlayer> queue;

        public DefenderSelectionValidator(IDeck<Data> deck, IBoard<Data> board, IMap<ICard, Data> map, IPlayerQueue<IPlayer> queue)
        {
            this.deck = deck;
            this.board = board;
            this.map = map;
            this.queue = queue;
        }

        public bool Validate(ICard value)
        {
            AssertState(board, queue);

            IPlayer current = queue.Current;

            Data selected = map.Get(value);

            Data last = board.Last();

            if (board.IsEmpty)
            {
                Debug.Log($"In defending state the board can't be empty");

                return false;
            }

            if (current.Hand.Contains(selected) is false)
            {
                Debug.Log($"Hand does not contains card: {selected}");

                return false;
            }

            if (selected.CanBeat(last, deck.Bottom) is false)
            {
                Debug.Log($"Can't beat. Selected: {selected}, Last: {last}, Tramp: {deck.Bottom}");

                return false;
            }

            return true;
        }

        private static void AssertState(IReadonlyBoard<Data> board, IReadonlyPlayerQueue<IPlayer> playerQueue)
        {
            Assert.IsTrue(playerQueue.IsDefenderQueue, "DefenderSelectionValidator can only validate defender selection");

            Assert.IsFalse(board.IsEmpty, "Defender can't beat no cards");
        }
    }
}