
using NUnit.Framework;

using ProjectCard.DurakModule.CardModule.ExtensionModule;

namespace ProjectCard.DurakModule.CardModule
{
    public class DataTest
    {
        [Test]
        public void DataHighCanBeatLowCardTrue()
        {
            Data trump = new Data(suit: 2, rank: 0);

            Data low = new Data(suit: 0, rank: 4);
            Data high = new Data(suit: 0, rank: 6);

            Assert.IsTrue(high.CanBeat(low, trump));
        }
        [Test]
        public void DataLowCanBeatCardHighFalse()
        {
            Data trump = new Data(suit: 2, rank: 0);

            Data low = new Data(suit: 0, rank: 4);
            Data high = new Data(suit: 0, rank: 6);

            Assert.IsFalse(low.CanBeat(high, trump));
        }
    }
}
