

using System.IO;

using Cysharp.Threading.Tasks;

namespace Framework.Shared.Serializations
{
    public interface ISerializer
    {
        UniTask<bool> Serialize<T>(Stream stream, T data);
    }
}
