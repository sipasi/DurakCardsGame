
using Framework.Durak.Players;

using UnityEngine;

namespace Framework.Durak.Gameplay.Events
{
    [CreateAssetMenu(fileName = "CurrentPlayerSwitched", menuName = "MyAsset/Durak/Gameplay/Events/CurrentPlayerSwitched")]
    public class CurrentPlayerSwitched : ScriptableObject
    {
        public delegate void QueueChanged(IReadonlyPlayer before, IReadonlyPlayer current);

        public event QueueChanged Switched;

        public void OnSwitched(IReadonlyPlayer before, IReadonlyPlayer current)
            => Switched?.Invoke(before, current);
    }
}
