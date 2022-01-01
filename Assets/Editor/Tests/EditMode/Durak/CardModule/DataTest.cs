
using NUnit.Framework;

using ProjectCard.Durak.CardModule;
using ProjectCard.Durak.CardModule.ExtensionModule;

namespace ProjectCard.Durak.Datas
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
