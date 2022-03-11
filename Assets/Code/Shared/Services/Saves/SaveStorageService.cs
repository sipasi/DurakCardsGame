using Cysharp.Threading.Tasks;

using Framework.Shared.Collections;
using Framework.Shared.Services.Storages;

namespace Framework.Shared.Services.Saves
{
    public class SaveStorageService<TKey> : SaveService, IStorage<TKey>
    {
        private IStorage<TKey> storage;

        public SaveStorageService(IStorageService storage) : base(storage) { }

        public int Count => storage.Count;

        public override async UniTask LoadStorage()
        {
            var result = await StorageService.Load<TKey>();

            storage = result ?? new Storage<TKey>();
        }
        public override async UniTask<bool> SaveStorage()
        {
            return await StorageService.Save(storage);
        }

        public void Store(TKey key, object data)
            => storage.Store(key, data);

        public TData Restore<TData>(TKey key) => storage.Restore<TData>(key);
        public T RestoreOrCreate<T>(TKey key) where T : new() => storage.RestoreOrCreate<T>(key);

        public bool Contains(TKey key) => storage.Contains(key);

        public void Clear() => storage.Clear();
    }
}