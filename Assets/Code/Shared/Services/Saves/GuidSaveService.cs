

using System;

using Framework.Shared.Services.Storages;


namespace Framework.Shared.Services.Saves
{
    public sealed class GuidSaveService : SaveStorageService<Guid>
    {
        public GuidSaveService(IStorageService storage) : base(storage) { }
    }
}