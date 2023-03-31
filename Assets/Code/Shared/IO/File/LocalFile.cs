using System.IO;

using Framework.Shared.Serializations;

namespace Framework.Shared.IO
{
    public class LocalFile<T> : IFile<T>
    {
        private readonly FileInfo file;
        private readonly ISerializer serializer;

        public LocalFile(ISerializer serializer, string path)
        {
            file = new FileInfo(path);

            this.serializer = serializer;
        }

        public T Load()
        {
            using FileStream stream = GetFileStream(FileMode.OpenOrCreate, FileAccess.Read);

            return serializer.Deserialize<T>(stream);
        }
        public bool Save(T data)
        {
            using FileStream stream = GetFileStream(FileMode.Create, FileAccess.Write);

            return serializer.Serialize(stream, data);
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