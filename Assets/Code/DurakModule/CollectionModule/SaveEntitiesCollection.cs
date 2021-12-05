using System.Collections.Generic;

using ProjectCard.Shared.SaveModule;

using UnityEngine;

namespace ProjectCard.DurakModule.CollectionModule
{
    public class SaveEntitiesCollection : MonoBehaviour
    {
        [SerializeField] private List<CustomSaverLoader> entities;

        public List<CustomSaverLoader>.Enumerator GetEnumerator() => entities.GetEnumerator();
    }
}