using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Framework.Shared.Serialization.Tests
{
    public class EntityBinarySerialization : EntitySerialization
    {
        protected override object Deserialize(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        protected override void Serialize<T>(Stream stream, T data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, data);
        }
    }
}
