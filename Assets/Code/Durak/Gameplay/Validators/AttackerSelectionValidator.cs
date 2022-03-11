using Framework.Durak.Collections.Extensions;
using Framework.Durak.Datas;
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Collections;
using Framework.Shared.Collections.Extensions;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Validators
{
    public class AttackerSelectionValidator : IValidator<ICard>, IAttackerValidator
    {
        private readonly IBoard<Data> board;
        private readonly IMap<ICard, Data> map;
        private readonly IPlayerQueue<IPlayer> queue;

        public AttackerSelectionValidator(IBoard<Data> board, IMap<ICard, Data> map, IPlayerQueue<IPlayer> queue)
        {
            this.board = board;
            this.map = map;
            this.queue = queue;
        }

        public bool Validate(ICard value)
        {
            AssertState(queue);

            IPlayer current = queue.Current;

            Data selected = map.Get(value);

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

        private static void AssertState(IReadonlyPlayerQueue<IPlayer> playerQueue)
        {
            Assert.IsTrue(playerQueue.IsAttackerQueue, "AttackerSelectionValidator can only validate attacker selection");
        }
    }
}