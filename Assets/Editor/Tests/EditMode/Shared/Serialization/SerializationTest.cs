using System;
using System.IO;
using System.Linq;

using Framework.Durak.Datas;
using Framework.Shared.Collections;
using Framework.Shared.Tests;

using NUnit.Framework;

namespace Framework.Shared.Serialization
{
    public abstract class SerializationTest
    {
        [Test]
        public void DeckData_True()
        {
            Deck<Data> entity = EntityCreator.CreateDeck(count: 56);

            SerializationDeserialization(entity, out var deserialized);

            Assert.IsTrue(entity.SequenceEqual(deserialized));
        }
        [Test]
        public void BoardData_True()
        {
            Board<Data> entity = EntityCreator.CreateBoard(row_count: 6);

            SerializationDeserialization(entity, out var deserialized);

            Assert.IsTrue(entity.SequenceEqual(deserialized));
        }
        [Test]
        public void DecrementalIndexes_True()
        {
            DecrementalIndexes entity = EntityCreator.CreateDecrementalIndexes(count: 6);

            SerializationDeserialization(entity, out var deserialized);

            Assert.IsTrue(entity.SequenceEqual(deserialized));
        }

        [Test()]
        public void SaveData_True()
        {
            SerializationDeserialization(DataToCompare.data, out var deserialized);

            Assert.IsTrue(DataToCompare.Compare(deserialized));
        }
        [Test]
        public void StorageGuid_True()
        {
            SerializationDeserialization(StorageToCompare<Guid>._storage, out var deserialized);

            Assert.IsTrue(StorageToCompare<Guid>.Compare(deserialized));
        }

        [Test]
        public void MapGuidData_True()
        {
            int count = 10;

            Map<Guid, Data> entity = EntityCreator.CreateMap(count);

            SerializationDeserialization(entity, out var deserialized);

            Assert.IsTrue(entity.Forward.SequenceEqual(deserialized.Forward));
            Assert.IsTrue(entity.Reverse.SequenceEqual(deserialized.Reverse));

            deserialized.Add(Guid.NewGuid(), new Data(-1, -1));
            deserialized.Add(Guid.NewGuid(), new Data(-2, -2));

            Assert.IsFalse(deserialized.Count == count);
            Assert.IsFalse(deserialized.Reverse.Count == count);
            Assert.IsFalse(deserialized.Forward.Count == count);

            Assert.IsTrue(deserialized.Count == deserialized.Forward.Count);
            Assert.IsTrue(deserialized.Count == deserialized.Forward.Count);
        }

        protected abstract void Serialize<T>(Stream stream, T data);
        protected abstract T Deserialize<T>(Stream stream);

        private void SerializationDeserialization<T>(T origin, out T deserialized)
            where T : class
        {
            using MemoryStream serialization = new();

            try
            {
                Serialize(serialization, origin);

                serialization.Flush();

                serialization.Position = 0;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

                deserialized = default;

                return;
            }

            using MemoryStream deserialization = new(serialization.GetBuffer());

            try
            {
                deserialized = Deserialize<T>(deserialization);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

                deserialized = default;

                return;
            }

            Assert.IsTrue(deserialized != null);

            Assert.IsFalse(ReferenceEquals(origin, deserialized));
        }
    }
}