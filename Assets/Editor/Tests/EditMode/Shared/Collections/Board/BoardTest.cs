
using Framework.Shared.Collections.Extensions;

using NUnit.Framework;

using System;

namespace Framework.Shared.Collections.Tests
{
    public class BoardTest
    {
        private static readonly int itemsPerRow = 6;
        private static readonly int total = itemsPerRow * 2;


        [Test]
        public void Test_AddToAttacks_FillAttacks()
        {
            Board<int> board = CreateBoard();

            Fill(method: board.AddToAttacks, count: itemsPerRow);

            Assert.IsTrue(board.IsAttacksFull);

            Assert.IsTrue(board.Defends.IsEmpty());
        }
        [Test]
        public void Test_AddToDefends_FillDefends()
        {
            Board<int> board = CreateBoard();

            Fill(method: board.AddToDefends, count: itemsPerRow);

            Assert.IsTrue(board.IsDefendsFull);

            Assert.IsTrue(board.Attacks.IsEmpty());
        }
        [Test]
        public void Test_Add_FillAll()
        {
            Board<int> board = CreateBoard();

            Fill(method: board.Add, count: total);

            Assert.IsTrue(board.IsFull);

            Assert.IsTrue(board.IsAttacksFull);
            Assert.IsTrue(board.IsDefendsFull);
        }

        private static Board<int> CreateBoard() => new Board<int>(itemsPerRow);

        private static void Fill(Action<int> method, int count)
        {
            for (int i = 0; i < count; i++)
            {
                method.Invoke(i);
            }
        }
    }
}