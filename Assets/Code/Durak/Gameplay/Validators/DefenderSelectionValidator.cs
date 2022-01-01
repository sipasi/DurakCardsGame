
using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.CardModule.ExtensionModule;
using ProjectCard.Durak.PlayerModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.Collections;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.Durak.ValidatorModule
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