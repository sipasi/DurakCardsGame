
using System.IO;

using Cysharp.Threading.Tasks;

namespace Framework.Shared.Serializations
{
    public interface IDeserializer
    {
        UniTask<T> Deserialize<T>(Stream stream);
    }
}
