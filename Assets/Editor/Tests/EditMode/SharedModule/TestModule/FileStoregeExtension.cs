﻿
using ProjectCard.Shared.ServiceModule.StorageModule;

namespace ProjectCard.Shared.ToolModule
{ 
    public static class FileStoregeExtension
    {
        public static void SetFields(this FileStorage storage, string directory, string file, string extension)
        {
            storage.SetPrivateField(name: nameof(directory), value: directory);
            storage.SetPrivateField(name: nameof(file), value: file);
            storage.SetPrivateField(name: nameof(extension), value: extension);
        }
    }
}