using Framework.Durak.Collections.Extensions;
using Framework.Durak.Datas;
using Framework.Durak.Entities;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Validators
{
    public class AttackerSelectionValidator : SelectionValidator
    {
        public override bool Validate(ICard value)
        {
            var (board, _, playerQueue) = this;

            AssertState(playerQueue);

            IReadonlyPlayer current = playerQueue.Current.Value;

            Data selected = ConvertToData(value);

            if (current.Contains(selected) is false)
            {
                return false;
            }

            if (board.IsEmpty)
            {
                return true;
            }

            if (board.IsAttacksFull)
            {
                return false;
            }

            bool contains = board.ContainsRank(selected);

            if (contains is false)
            {
                Debug.Log($"Board does not contais rank: {selected}");
            }

            return contains;
        }

        private static void AssertState(IReadonlyPlayerQueue<IPlayerEntity> playerQueue)
        {
            Assert.IsTrue(playerQueue.IsAttackerQueue, "AttackerSelectionValidator can only validate attacker selection");
        }
    }
}