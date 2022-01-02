﻿
using Framework.Shared.IO;

using UnityEngine;

namespace Framework.Shared.Services.Storages
{
    [CreateAssetMenu(fileName = "LocalBinaryFileStorage", menuName = "MyAsset/Shared/ServiceModule/Storage LocalFile Binary")]
    public sealed class LocalBinaryFileStorageService : FileStorage
    {
        protected override IFileAsync GetFile()
        {
            IFileAsync file = new BinaryFile(FullPath);

            return file;
        }
    }
}