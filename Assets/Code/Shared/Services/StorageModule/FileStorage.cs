#nullable enable
 
using System.IO;

using Cysharp.Threading.Tasks;

using ProjectCard.Shared.Collections;
using ProjectCard.Shared.IO;

using UnityEngine;

namespace ProjectCard.Shared.Services.StorageModule
{
    public abstract class FileStorage : ScriptableStorage
    {
        [Header("Path")]
        [SerializeField] private string directory = string.Empty;
        [SerializeField] private string file = string.Empty;
        [SerializeField] private string extension = string.Empty;

        public string LocalPath => Path.Combine(directory, $"{file}.{extension}");
        public string FullPath => Path.Combine(Application.persistentDataPath, LocalPath);

        public override async UniTask<IStorage<T>?> Load<T>()
        {
            IFileAsync file = GetFile();

            var result = await file.LoadAsync<IStorage<T>>();

            return result;
        }

        public override async UniTask<bool> Save(object data)
        {
            IFileAsync file = GetFile();

            return await file.SaveAsync(data);
        }

        protected abstract IFileAsync GetFile();
    }
}