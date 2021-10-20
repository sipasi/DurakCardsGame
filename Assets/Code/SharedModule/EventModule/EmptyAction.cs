
using System;

using UnityEngine;

namespace ProjectCard.Shared.EventModule
{
    [CreateAssetMenu(fileName = "EmptyEvent", menuName = "MyAsset/Shared/EventModule/EmptyEvent")]
    public class EmptyAction : ScriptableObject
    {
        public event Action Action;

        public void Rise()
        {
            Action?.Invoke();
        }
    }
}