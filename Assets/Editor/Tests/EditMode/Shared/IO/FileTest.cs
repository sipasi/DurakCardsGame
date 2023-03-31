using System.IO;

using Framework.Shared.IO;
using Framework.Shared.Tests;

using NUnit.Framework;

using UnityEngine;

namespace ProjectCard.Editor.TestModule.IO
{
    public abstract class FileTest
    {
        protected abstract string LocalPath { get; }
        protected string FullPath
            => Path.Combine(Application.persistentDataPath, "Test", nameof(IO), LocalPath);

        protected abstract IFile<SaveData> GetFile();

        [Test]
        public void SaveLoad_True()
        {
            SaveSerializableOperation();
            LoadSerializableOperation();
        }

        private void SaveSerializableOperation()
        {
            IFile<SaveData> file = GetFile();

            bool result = file.Save(DataToCompare.data);

            Assert.IsTrue(result);
        }
        private void LoadSerializableOperation()
        {
            IFile<SaveData> file = GetFile();

            var result = file.Load();

            Assert.IsNotNull(result);

            bool compare = DataToCompare.Compare(result);

            Assert.IsTrue(compare);
        }
    }
}