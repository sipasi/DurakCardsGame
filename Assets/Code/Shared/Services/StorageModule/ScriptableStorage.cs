#nullable enable

using Cysharp.Threading.Tasks;

using Framework.Shared.Collections;

using UnityEngine;

namespace Framework.Shared.Services.Storages
{
    public abstract class ScriptableStorage : ScriptableObject
    {
        public abstract UniTask<IStorage<T>?> Load<T>();
        public abstract UniTask<bool> Save(object data);
    }
}