#nullable enable 

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.SaveModule
{
    [CreateAssetMenu(fileName = "StringSaveService", menuName = "MyAsset/Shared/ServiceModule/SaveService by string")]
    public sealed class StringSaveService : SaveStorageService<string> { }
}