using Framework.Shared.Collections;

namespace Framework.Shared.Tests
{
    public static class StorageToCompare<TKey> where TKey : new()
    {
        public static readonly int _length = 10;

        private static readonly TKey key = new TKey();

        public static readonly IReadonlyStorage<TKey> _storage = CreateStorage();

        public static bool Compare(IReadonlyStorage<TKey> readonlyStorage)
        {
            var local = _storage as IStorage<TKey>;
            var storage = readonlyStorage as IStorage<TKey>;

            if (storage is null)
            {
                return false;
            }

            var countResult = local.Count == storage.Count;

            if (countResult is false)
                return false;

            SaveData saveData = storage.Restore<SaveData>(key);
            SaveData localSaveData = local.Restore<SaveData>(key);

            bool saveDataResult = saveData.Compare(localSaveData);

            return saveDataResult;
        }

        private static Storage<TKey> CreateStorage()
        {
            var storage = new Storage<TKey>();

            storage.Store(key, DataToCompare.data);

            return storage;
        }
    }
}