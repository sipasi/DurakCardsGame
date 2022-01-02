
using Framework.Durak.Cards;
using Framework.Durak.Cards.Extensions;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Validators
{
    public class DefenderSelectionValidator : SelectionValidator
    {
        public override bool Validate(ICard value)
        {
            var (board, deck, playerQueue) = this;

            AssertState(board, playerQueue);

            IPlayer current = playerQueue.Current;

            Data selected = ConvertToData(value);

            board.TryGetLast(out var last);

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

        private static void AssertState(IBoard<Data> board, IPlayerQueue playerQueue)
        {
            Assert.IsTrue(playerQueue.IsDefenderQueue, "DefenderSelectionValidator can only validate defender selection");
            Assert.IsFalse(board.IsEmpty, "Defender can't beat no cards");
        }
    }
}