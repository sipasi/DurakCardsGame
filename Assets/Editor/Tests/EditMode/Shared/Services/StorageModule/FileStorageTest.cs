using Cysharp.Threading.Tasks;

using Framework.Shared.Tests;

using NUnit.Framework;

using ProjectCard.Editor.TestModule.ToolModule;

using System;
using System.Collections;

using UnityEngine;
using UnityEngine.TestTools;

namespace Framework.Shared.Services.Storages.Tests
{
    public abstract class FileStorageTest
    {
        private string FileDirectory => Application.persistentDataPath;
        protected abstract string FileName { get; }
        protected abstract string FileExtension { get; }

        protected abstract FileStorage GetFileStorage();


        [UnityTest]
        public IEnumerator SaveLoad_KeyInt_True()
        {
            return SaveLoadOperation<int>().ToCoroutine();
        }
        [UnityTest]
        public IEnumerator SaveLoad_KeyGuid_True()
        {
            return SaveLoadOperation<Guid>().ToCoroutine();
        }

        private async UniTask SaveLoadOperation<TKey>() where TKey : new()
        {
            FileStorage file = GetFileStorage();

            SetFields(file);

            bool save_result = await file.Save(StorageToCompare<TKey>._storage);

            Assert.IsTrue(save_result, "Save result was false");

            var storage = await file.Load<TKey>();

            bool deserialize_equality = StorageToCompare<TKey>.Compare(storage);

            Assert.IsTrue(deserialize_equality, "Deserialize equality was false");
        }

        private void SetFields(FileStorage storage)
        {
            storage.SetFields(FileDirectory, FileName, FileExtension);
        }
    }
}