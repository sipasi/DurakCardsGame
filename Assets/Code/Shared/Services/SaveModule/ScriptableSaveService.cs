using Cysharp.Threading.Tasks;

using ProjectCard.Shared.Services.StorageModule;

using UnityEngine;

namespace ProjectCard.Shared.Services.SaveModule
{
    public abstract class ScriptableSaveService : ScriptableObject, ISaveService
    {
        [SerializeField] private ScriptableStorage storage;

        protected ScriptableStorage StorageService => storage;

        public abstract UniTask LoadStorage();
        public abstract UniTask<bool> SaveStorage();
    }
}