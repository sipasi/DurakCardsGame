
using Framework.Durak.Players;
using Framework.Shared.Events;

using UnityEngine;

namespace Framework.Durak.Gameplay.Events
{
    [CreateAssetMenu(fileName = "PlayerPassedEvent", menuName = "MyAsset/Durak/Gameplay/Events/PlayerPassedEvent")]
    public class PlayerPassedEvent : ScriptableAction<IPlayer> { }
}
