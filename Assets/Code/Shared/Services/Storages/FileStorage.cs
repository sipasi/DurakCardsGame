#nullable enable

using System.IO;

using Cysharp.Threading.Tasks;

using Framework.Shared.Collections;
using Framework.Shared.IO;

using UnityEngine;

namespace Framework.Shared.Services.Storages
{
    public interface IFileStorageService : IStorageService
    {
        string Directory { get; }
        string Name { get; }
        string Extension { get; }

        string LocalPath { get; }
        string FullPath { get; }
    }

    public abstract class FileStorage : IFileStorageService
    {
        private readonly string directory = string.Empty;
        private readonly string name = string.Empty;
        private readonly string extension = string.Empty;

        public string Directory => directory;
        public string Name => name;
        public string Extension => extension;

        public string LocalPath => Path.Combine(directory, $"{name}.{extension}");
        public string FullPath => Path.Combine(Application.persistentDataPath, LocalPath);

        protected FileStorage(string directory, string name, string extension)
        {
            this.directory = directory;
            this.name = name;
            this.extension = extension;
        }

        public async UniTask<IStorage<T>?> Load<T>()
        {
            IFileAsync file = GetFile();

            var result = await file.LoadAsync<IStorage<T>>();

            return result;
        }

        public async UniTask<bool> Save(object data)
        {
            IFileAsync file = GetFile();

            return await file.SaveAsync(data);
        }

        protected abstract IFileAsync GetFile();
    }
}