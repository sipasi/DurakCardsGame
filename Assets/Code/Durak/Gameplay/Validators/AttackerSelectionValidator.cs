
using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.CollectionModule.ExtensionModule;
using ProjectCard.Durak.PlayerModule;
using ProjectCard.Shared.CardModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.Durak.ValidatorModule
{
    public class AttackerSelectionValidator : SelectionValidator
    {
        public override bool Validate(ICard value)
        {
            var (board, _, playerQueue) = this;

            AssertState(playerQueue);

            IPlayer current = playerQueue.Current;

            Data selected = ConvertToData(value);

            if (current.Hand.Contains(selected) is false)
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

        private static void AssertState(IPlayerQueue playerQueue)
        {
            Assert.IsTrue(playerQueue.IsAttackerQueue, "AttackerSelectionValidator can only validate attacker selection");
        }
    }
}