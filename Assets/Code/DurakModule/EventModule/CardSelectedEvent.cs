
using ProjectCard.DurakModule.PlayerModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;
namespace ProjectCard.DurakModule.EventModule
{
    [CreateAssetMenu(fileName = "CardSelectedEvent", menuName = "MyAsset/Durak/EventModule/CardSelectedEvent")]
    public class CardSelectedEvent : ScriptableAction<IPlayer, ICard> { }
}
