#nullable enable

using Cysharp.Threading.Tasks;

using ProjectCard.Shared.Collections;

using UnityEngine;

namespace ProjectCard.Shared.Services.StorageModule
{
    public abstract class ScriptableStorage : ScriptableObject
    {
        public abstract UniTask<IStorage<T>?> Load<T>();
        public abstract UniTask<bool> Save(object data);
    }
}