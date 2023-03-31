using System.IO;

using Framework.Shared.Serializations;

namespace Framework.Shared.Serialization
{
    public class BinarySerialization : SerializationTest
    {
        private readonly BinarySerializer serializer = new();

        protected override void Serialize<T>(Stream stream, T data) => serializer.Serialize(stream, data);

        protected override T Deserialize<T>(Stream stream)
        {
            T result = serializer.Deserialize<T>(stream);

            return result;
        }
    }
}
