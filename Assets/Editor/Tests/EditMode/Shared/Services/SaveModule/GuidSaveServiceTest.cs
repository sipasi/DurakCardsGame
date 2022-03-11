using Cysharp.Threading.Tasks;

using Framework.Shared.Services.Storages;
using Framework.Shared.Tests;

using NUnit.Framework;

using System;
using System.Collections;

using UnityEngine.TestTools;

namespace Framework.Shared.Services.Saves.Tests
{
    public class SaveStorageServiceTest
    {
        private static readonly string directory = System.IO.Path.Combine("Test", typeof(SaveStorageServiceTest).FullName);

        [UnityTest]
        public IEnumerator SaveLoad_KeyGuid_StorageBinaryFile_True()
        {
            string name = "guidSaveFile";
            string extension = "binary";

            var storageService = new LocalBinaryFileStorageService(directory, name, extension);
            var saveService = new GuidSaveService(storageService);


            var task = SaveLoadFileOperation(service: saveService, key: Guid.NewGuid());

            return task.ToCoroutine();
        }

        [UnityTest]
        public IEnumerator SaveLoad_KeyString_StorageBinaryFile_True()
        {
            string name = "stringSaveFile";
            string extension = "binary";

            var storageService = new LocalBinaryFileStorageService(directory, name, extension);
            var saveService = new StringSaveService(storageService);

            var task = SaveLoadFileOperation(service: saveService, key: "binary_string_key");

            return task.ToCoroutine();
        }

        private UniTask SaveLoadFileOperation<TKey>(SaveStorageService<TKey> service, TKey key)
        {
            return SaveLoadOperation(service, key);
        }
        private async UniTask SaveLoadOperation<TKey>(SaveStorageService<TKey> service, TKey key)
        {
            await service.LoadStorage();

            service.Clear();

            service.Store(key, DataToCompare.data);

            var save_result = await service.SaveStorage();

            Assert.IsTrue(save_result);

            await service.LoadStorage();

            var restored = service.Restore<SaveData>(key);

            Assert.IsNotNull(restored);

            bool compare = DataToCompare.Compare(restored);

            Assert.IsTrue(compare);
        }
    }
}
