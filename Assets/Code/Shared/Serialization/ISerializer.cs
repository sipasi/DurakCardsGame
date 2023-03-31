using System.IO;

namespace Framework.Shared.Serializations
{
    public interface ISerializer
    {
        bool Serialize<T>(Stream stream, T data);
        T Deserialize<T>(Stream stream);
    }
}
