

using UnityEngine;

namespace Framework.Shared.Services.Saves
{
    [CreateAssetMenu(fileName = "StringSaveService", menuName = "MyAsset/Shared/ServiceModule/SaveService by string")]
    public sealed class StringSaveService : SaveStorageService<string> { }
}