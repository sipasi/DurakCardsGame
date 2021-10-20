
using System;

using UnityEngine;

namespace ProjectCard.Shared.EventModule
{
    public class ScriptableAction<T> : ScriptableObject
    {
        public event Action<T> Action;

        public void Rise(T item)
        {
            Action?.Invoke(item);
        }
    }
    public class ScriptableAction<T1, T2> : ScriptableObject
    {
        public event Action<T1, T2> Action;

        public void Rise(T1 item1, T2 item2)
        {
            Action?.Invoke(item1, item2);
        }
    }
}