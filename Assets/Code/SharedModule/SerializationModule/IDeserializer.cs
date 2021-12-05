
using System.IO;

using Cysharp.Threading.Tasks;

namespace ProjectCard.Shared.SerializationModule
{
    public interface IDeserializer
    {
        UniTask<T> Deserialize<T>(Stream stream);
    }
}
