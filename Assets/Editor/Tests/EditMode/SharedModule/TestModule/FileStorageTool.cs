using ProjectCard.Shared.ServiceModule.StorageModule;

using UnityEngine;

namespace ProjectCard.Shared.ToolModule
{
    public static class FileStorageTool
    {
        public static T Create<T>(string directory, string file, string extension) where T : FileStorage
        {
            var storage = ScriptableObject.CreateInstance<T>();

            storage.SetFields(directory, file, extension);

            return storage;
        }
    }
}