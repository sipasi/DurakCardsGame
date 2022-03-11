

using Cysharp.Threading.Tasks;

using Framework.Shared.Serializations;

using System.IO;

namespace Framework.Shared.IO
{
    public abstract class LocalFileSerializer : Serializer, IFileAsync
    {
        private readonly FileInfo file;


        public LocalFileSerializer(string directory, string name)
            : this(Path.Combine(directory, name)) { }
        public LocalFileSerializer(string path)
            => file = new FileInfo(path);


        public async UniTask<T> LoadAsync<T>()
        {
            using FileStream stream = GetFileStream(FileMode.OpenOrCreate, FileAccess.Read);

            return await Deserialize<T>(stream);
        }
        public async UniTask<bool> SaveAsync<T>(T data)
        {
            using FileStream stream = GetFileStream(FileMode.Create, FileAccess.Write);

            return await Serialize(stream, data);
        }

        private FileStream GetFileStream(FileMode mode, FileAccess access, FileShare share = FileShare.None)
        {
            DirectoryInfo directory = file.Directory;

            if (directory.Exists is false)
            {
                directory.Create();
            }

            FileStream stream = file.Open(mode, access, share);

            return stream;
        }
    }
}