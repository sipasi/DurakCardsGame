#nullable enable 

using ProjectCard.Shared.IO;

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.StorageModule
{
    [CreateAssetMenu(fileName = "LocalBinaryFileStorage", menuName = "MyAsset/Shared/ServiceModule/Storage LocalFile Binary")]
    public sealed class LocalBinaryFileStorageService : FileStorage
    {
        protected override IFileAsync GetFile()
        {
            var file = new BinaryFile(FullPath);

            return file;
        }
    }
}