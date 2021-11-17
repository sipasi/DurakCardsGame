
using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.StorageModule
{
    public class LocalBinaryFileStorageServiceTest : ScriptableFileStorageTest
    {
        protected override string FileName => "file";
        protected override string FileExtension => "binary";

        protected override FileStorage GetFileStorage()
        {
            return ScriptableObject.CreateInstance<LocalBinaryFileStorageService>();
        }
    }
}
