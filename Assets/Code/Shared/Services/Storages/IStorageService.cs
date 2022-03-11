#nullable enable

using Cysharp.Threading.Tasks;

using Framework.Shared.Collections;

namespace Framework.Shared.Services.Storages
{
    public interface IStorageService
    {
        UniTask<IStorage<T>?> Load<T>();
        UniTask<bool> Save(object data);
    }
}