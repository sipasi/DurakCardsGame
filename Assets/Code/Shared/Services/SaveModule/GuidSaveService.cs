

using System;

using UnityEngine;

namespace ProjectCard.Shared.Services.SaveModule
{
    [CreateAssetMenu(fileName = "GuidSaveService", menuName = "MyAsset/Shared/ServiceModule/SaveService by Guid")]
    public sealed class GuidSaveService : SaveStorageService<Guid> { }
}