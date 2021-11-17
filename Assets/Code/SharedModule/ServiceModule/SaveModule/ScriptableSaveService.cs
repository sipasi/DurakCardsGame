using Cysharp.Threading.Tasks;

using ProjectCard.Shared.ServiceModule.StorageModule;

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.SaveModule
{
    public abstract class ScriptableSaveService : ScriptableObject, ISaveService
    {
        [SerializeField] private ScriptableStorage storage;

        protected ScriptableStorage StorageService => storage;

        public abstract UniTask LoadStorage();
        public abstract UniTask<bool> SaveStorage();
    }
}