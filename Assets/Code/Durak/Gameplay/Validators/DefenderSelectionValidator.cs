
using Framework.Durak.Datas;
using Framework.Durak.Datas.Extensions;
using Framework.Durak.Entities;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

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

            IReadonlyPlayer current = playerQueue.Current.Value;

            Data selected = ConvertToData(value);

            Data last = board.Last();

            if (board.IsEmpty)
            {
                Debug.Log($"In defending state the board can't be empty");

                return false;
            }

            if (current.Contains(selected) is false)
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

        private static void AssertState(IReadonlyBoard<Data> board, IReadonlyPlayerQueue<IPlayerEntity> playerQueue)
        {
            Assert.IsTrue(playerQueue.IsDefenderQueue, "DefenderSelectionValidator can only validate defender selection");
            Assert.IsFalse(board.IsEmpty, "Defender can't beat no cards");
        }
    }
}