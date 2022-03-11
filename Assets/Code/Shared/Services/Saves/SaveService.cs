using Cysharp.Threading.Tasks;

using Framework.Shared.Services.Storages;

namespace Framework.Shared.Services.Saves
{
    public abstract class SaveService : ISaveService
    {
        private readonly IStorageService storage;

        public IStorageService StorageService => storage;

        protected SaveService(IStorageService storage) => this.storage = storage;

        public abstract UniTask LoadStorage();
        public abstract UniTask<bool> SaveStorage();
    }
}