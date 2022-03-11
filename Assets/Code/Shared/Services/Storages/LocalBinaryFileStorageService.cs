
using Framework.Shared.IO;

namespace Framework.Shared.Services.Storages
{
    public sealed class LocalBinaryFileStorageService : FileStorage
    {
        public LocalBinaryFileStorageService(string directory, string name, string extension) : base(directory, name, extension) { }

        protected override IFileAsync GetFile()
        {
            IFileAsync file = new BinaryFile(FullPath);

            return file;
        }
    }
}