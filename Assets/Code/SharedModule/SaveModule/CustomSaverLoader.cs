
using System;

using ProjectCard.Shared.CollectionModule;

using UnityEngine;

namespace ProjectCard.Shared.SaveModule
{
    public abstract class CustomSaverLoader : MonoBehaviour, ISavableEntity<Guid>, ILoadableEntity<Guid>
    {
        [SerializeField] private SaveKey key;

        public Guid Key => key.Key;

        public abstract void Load(IStorage<Guid> storage);
        public abstract void Save(IStorage<Guid> storage);
    }
}