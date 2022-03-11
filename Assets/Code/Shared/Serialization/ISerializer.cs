

using Cysharp.Threading.Tasks;

using System.IO;

namespace Framework.Shared.Serializations
{
    public interface ISerializer
    {
        UniTask<bool> Serialize<T>(Stream stream, T data);
    }
}
