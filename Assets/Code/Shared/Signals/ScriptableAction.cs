
using System;

using UnityEngine;

namespace Framework.Shared.Events
{
    [CreateAssetMenu(fileName = "Action", menuName = "MyAsset/Shared/Events/Action")]
    public class ScriptableAction : ScriptableObject
    {
        public event Action Event;

        public void Rise() => Event?.Invoke();
    }
}