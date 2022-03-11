using Framework.Shared.Services.Storages;

namespace Framework.Shared.Services.Saves
{
    public sealed class StringSaveService : SaveStorageService<string>
    {
        public StringSaveService(IStorageService storage) : base(storage) { }
    }
}