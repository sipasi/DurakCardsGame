

using Cysharp.Threading.Tasks;

using Framework.Shared.Services.Storages;

namespace Framework.Shared.Services.Saves
{
    public interface ISaveService
    {
        IStorageService StorageService { get; }

        UniTask LoadStorage();
        UniTask<bool> SaveStorage();
    }
}