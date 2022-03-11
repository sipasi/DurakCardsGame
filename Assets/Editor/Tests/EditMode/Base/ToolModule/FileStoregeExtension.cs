using Framework.Shared.Services.Storages;

namespace ProjectCard.Editor.TestModule.ToolModule
{
    public static class FileStoregeExtension
    {
        public static void SetFields(this FileStorage storage, string directory, string name, string extension)
        {
            storage.SetPrivateField(name: nameof(directory), value: directory);
            storage.SetPrivateField(name: nameof(name), value: name);
            storage.SetPrivateField(name: nameof(extension), value: extension);
        }
    }
}