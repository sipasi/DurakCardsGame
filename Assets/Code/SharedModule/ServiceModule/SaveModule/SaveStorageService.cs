using Cysharp.Threading.Tasks;

using ProjectCard.Shared.CollectionModule;

namespace ProjectCard.Shared.ServiceModule.SaveModule
{
    public class SaveStorageService<TKey> : ScriptableSaveService, IStorage<TKey>
    {
        private IStorage<TKey> storage;

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