

using UnityEngine;

namespace ProjectCard.Shared.Services.SaveModule
{
    [CreateAssetMenu(fileName = "StringSaveService", menuName = "MyAsset/Shared/ServiceModule/SaveService by string")]
    public sealed class StringSaveService : SaveStorageService<string> { }
}