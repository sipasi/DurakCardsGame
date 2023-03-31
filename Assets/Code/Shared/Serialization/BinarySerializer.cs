using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Framework.Shared.Serializations
{
    public sealed class BinarySerializer : Serializer
    {
        protected override void SerializeObject<T>(Stream stream, T data)
        {
            BinaryFormatter formatter = new();

            formatter.Serialize(stream, data);
        }

        protected override T DeserializeObject<T>(Stream stream)
        {
            BinaryFormatter formatter = new();

            var result = formatter.Deserialize(stream);

            return (T)result;
        }
    }
}