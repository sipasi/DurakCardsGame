using System;
using System.Collections.Generic;

using ProjectCard.Shared.SaveModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.CollectionModule
{
    public class SaveEntitiesCollection : MonoBehaviour
    {
        [SerializeField] private List<GameObject> entities;
        [SerializeField] private List<ScriptableObject> scriptables;

        public IEnumerable<ISavableEntity<Guid>> GetSavableEntities() => Enumerate<ISavableEntity<Guid>>();
        public IEnumerable<ILoadableEntity<Guid>> GetLoadableEntities() => Enumerate<ILoadableEntity<Guid>>();

        private IEnumerable<T> Enumerate<T>() where T : class
        {
            foreach (var item in scriptables)
            {
                var value = item as T;

                Assert.IsNotNull(value, $"Can't cast scriptable to [{typeof(T)}]");

                yield return value;
            }

            foreach (var item in entities)
            {
                var value = item.GetComponent<T>();

                Assert.IsNotNull(value, $"Can't get component of [{typeof(T)}]");

                yield return value;
            }
        }
    }
}