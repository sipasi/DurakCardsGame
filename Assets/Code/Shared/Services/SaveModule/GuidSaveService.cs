

using System;

using UnityEngine;

namespace Framework.Shared.Services.Saves
{
    [CreateAssetMenu(fileName = "GuidSaveService", menuName = "MyAsset/Shared/ServiceModule/SaveService by Guid")]
    public sealed class GuidSaveService : SaveStorageService<Guid> { }
}