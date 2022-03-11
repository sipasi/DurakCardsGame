
using NUnit.Framework;

namespace Framework.Shared.Collections.Tests
{
    public class DecrementalIndexesTest
    {
        private static readonly int count = 10;

        private static readonly int first = 0;
        private static readonly int last = count - 1;

        [Test]
        public void Test()
        {
            IIndexCollection indexes = Create();

            Assert.AreEqual(count, indexes.Count);
            Assert.AreEqual(first, indexes.PeekFirst());
            Assert.AreEqual(last, indexes.Peek());

            indexes.Next();

            Assert.AreEqual(last - 1, indexes.Peek());
        }

        private static IIndexCollection Create() => new DecrementalIndexes(count);
    }
}