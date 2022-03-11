
using Framework.Shared.Collections.Extensions;

using NUnit.Framework;

using System.Collections.Generic;

namespace Framework.Shared.Collections.Tests
{
    public class DeckTest
    {
        private static readonly int suits = 2;
        private static readonly int ranks = 2;
        private static readonly int total = suits * ranks;

        private static readonly IReadOnlyList<int> list = CreateList();

        [Test]
        public void Test()
        {
            var deck = Create();

            Assert.AreEqual(total, deck.Count);

            int index = 0;

            while (deck.TryPop(out var data))
            {
                if (index > deck.Capacity)
                {
                    Assert.Fail();
                }

                index++;
            }

            Assert.IsTrue(deck.IsEmpty);
        }

        private static IDeck<int> Create()
        {
            var deck = new Deck<int>(list);

            return deck;
        }

        private static IReadOnlyList<int> CreateList()
        {
            var array = new int[total];

            array.FillNubers();

            return array;
        }
    }
}