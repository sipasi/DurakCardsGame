using Cysharp.Threading.Tasks;

using Framework.Shared.Services.Storages;

using UnityEngine;

namespace Framework.Shared.Services.Saves
{
    public abstract class ScriptableSaveService : ScriptableObject, ISaveService
    {
        [SerializeField] private ScriptableStorage storage;

        protected ScriptableStorage StorageService => storage;

        public abstract UniTask LoadStorage();
        public abstract UniTask<bool> SaveStorage();
    }
}