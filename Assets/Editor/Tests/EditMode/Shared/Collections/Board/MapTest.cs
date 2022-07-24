
using System.Collections.Generic;

using NUnit.Framework;

namespace Framework.Shared.Collections.Tests
{
    public class MapTest
    {

        [Test]
        public void Test()
        {
            int count = 4;

            IReadOnlyList<KeyValuePair<int, string>> pairs = GeneratePairs(count);

            Map<int, string> map = Create(pairs);

            foreach (var pair in pairs)
            {
                Assert.AreEqual(pair.Key, map.Reverse[pair.Value]);
                Assert.AreEqual(pair.Value, map.Forward[pair.Key]);
            }
        }

        private static Map<int, string> Create(IReadOnlyList<KeyValuePair<int, string>> pairs)
        {
            var map = new Map<int, string>(pairs.Count);

            foreach (var pair in pairs)
            {
                map.Add(pair.Key, pair.Value);
            }

            return map;
        }

        private static IReadOnlyList<KeyValuePair<int, string>> GeneratePairs(int count)
        {
            var pairs = new KeyValuePair<int, string>[count];

            for (int i = 0; i < count; i++)
            {
                pairs[i] = new KeyValuePair<int, string>(i, i.ToString());
            }

            return pairs;
        }
    }
}