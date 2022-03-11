
using UnityEngine;

namespace Framework.Shared.Services.Storages.Tests
{
    public class LocalBinaryFileStorageServiceTest : FileStorageTest
    {
        protected override string FileName => "file";
        protected override string FileExtension => "binary";

        protected override FileStorage GetFileStorage()
        {
            return new LocalBinaryFileStorageService(directory: Application.persistentDataPath, FileName, FileExtension);
        }
    }
}
