

using Cysharp.Threading.Tasks;

namespace Framework.Shared.IO
{
    public interface IFileAsync
    {
        UniTask<T> LoadAsync<T>();

        UniTask<bool> SaveAsync<T>(T data);
    }
}
