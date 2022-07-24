using System.Collections;
using System.IO;

using Cysharp.Threading.Tasks;

using Framework.Shared.IO;
using Framework.Shared.Tests;

using NUnit.Framework;

using UnityEngine;
using UnityEngine.TestTools;

namespace ProjectCard.Editor.TestModule.IO
{
    public abstract class FileTest
    {
        protected abstract string LocalPath { get; }
        protected string FullPath
            => Path.Combine(Application.persistentDataPath, "Test", nameof(IO), LocalPath);

        protected abstract IFileAsync GetFile();

        [UnityTest]
        public IEnumerator SaveLoad_True()
        {
            yield return SaveSerializableOperation().ToCoroutine();
            yield return LoadSerializableOperation().ToCoroutine();
        }

        private async UniTask SaveSerializableOperation()
        {
            IFileAsync file = GetFile();

            bool result = await file.SaveAsync(DataToCompare.data);

            Assert.IsTrue(result);
        }
        private async UniTask LoadSerializableOperation()
        {
            IFileAsync file = GetFile();

            var result = await file.LoadAsync<SaveData>();

            Assert.IsNotNull(result);

            bool compare = DataToCompare.Compare(result);

            Assert.IsTrue(compare);
        }
    }
}