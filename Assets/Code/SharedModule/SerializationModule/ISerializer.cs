#nullable enable

using System.IO;

using Cysharp.Threading.Tasks;

namespace ProjectCard.Shared.SerializationModule
{
    public interface ISerializer
    {
        UniTask<bool> Serialize<T>(Stream stream, T data);
    }
}
