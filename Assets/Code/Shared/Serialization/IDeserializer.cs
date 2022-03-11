
using Cysharp.Threading.Tasks;

using System.IO;

namespace Framework.Shared.Serializations
{
    public interface IDeserializer
    {
        UniTask<T> Deserialize<T>(Stream stream);
    }
}
