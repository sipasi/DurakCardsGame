
using System;

using ProjectCard.Shared.CollectionModule;
using ProjectCard.Shared.EntityModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.Shared.SaveModule
{
    public class EntitySaverLoader<T> : CustomSaverLoader
    {
        [SerializeField] private GameplayEntity<T> entity;

        public T Data => entity.Value;

        public override void Load(IStorage<Guid> storage)
        {
            var restored = storage.Restore<T>(Key);

            Assert.IsTrue(restored != null);

            InitializeEntity(restored!);
        }
        public override void Save(IStorage<Guid> storage)
        {
            storage.Store(Key, Data!);
        }

        protected void InitializeEntity(T data)
        {
            entity.Initialize(data);
        }
    }

}