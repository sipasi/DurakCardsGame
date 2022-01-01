
using ProjectCard.Durak.PlayerModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;
namespace ProjectCard.Durak.EventModule
{
    [CreateAssetMenu(fileName = "PlayerPassedEvent", menuName = "MyAsset/Durak/EventModule/PlayerPassedEvent")]
    public class PlayerPassedEvent : ScriptableAction<IPlayer> { }
}
