
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;
namespace ProjectCard.DurakModule.EventModule
{
    [CreateAssetMenu(fileName = "PlayerPassedEvent", menuName = "MyAsset/Durak/EventModule/PlayerPassedEvent")]
    public class PlayerPassedEvent : ScriptableAction<PlayerInfo> { }
}
