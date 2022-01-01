using System;
using System.Collections;

using Cysharp.Threading.Tasks;

using NUnit.Framework;

using ProjectCard.Editor.TestModule.TestData;
using ProjectCard.Editor.TestModule.ToolModule;
using ProjectCard.Shared.Services.SaveModule;
using ProjectCard.Shared.Services.StorageModule;

using UnityEngine;
using UnityEngine.TestTools;

namespace ProjectCard.Editor.TestModule.ServiceModule.SaveModule
{
    public class SaveStorageServiceTest
    {
        private static readonly string directory = System.IO.Path.Combine("Test", typeof(SaveStorageServiceTest).FullName);

        [UnityTest]
        public IEnumerator SaveLoad_KeyGuid_StorageBinaryFile_True()
        {
            var task = SaveLoadFileOperation<GuidSaveService, Guid, LocalBinaryFileStorageService>
                (key: Guid.NewGuid(), fileExtension: "binary");

            return task.ToCoroutine();
        }

        [UnityTest]
        public IEnumerator SaveLoad_KeyString_StorageBinaryFile_True()
        {
            var task = SaveLoadFileOperation<StringSaveService, string, LocalBinaryFileStorageService>
                (key: "binary_string_key", fileExtension: "binary");

            return task.ToCoroutine();
        }

        private UniTask SaveLoadFileOperation<TService, TKey, TStorage>(TKey key, string fileExtension)
            where TService : SaveStorageService<TKey>
            where TStorage : FileStorage
        {
            var storage = FileStorageTool.Create<TStorage>(directory, typeof(TStorage).Name, fileExtension);

            SaveStorageService<TKey> service = GetStorageService<TService>(storage);

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

        private TService GetStorageService<TService>(ScriptableStorage storage) where TService : ScriptableSaveService
        {
            var service = ScriptableObject.CreateInstance<TService>();

            Assert.IsNotNull(service, $"Can't create ScriptableObject by type[{typeof(TService)}]");

            Assert.IsNotNull(storage);

            SetSaveServiceField(service, storage);

            return service;
        }

        private void SetSaveServiceField(ScriptableSaveService service, ScriptableStorage storage)
        {
            var field_name = "storage";

            service.SetPrivateField(field_name, storage);
        }
    }
}
