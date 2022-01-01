
using ProjectCard.Durak.PlayerModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;
namespace ProjectCard.Durak.EventModule
{
    [CreateAssetMenu(fileName = "CardSelectedEvent", menuName = "MyAsset/Durak/EventModule/CardSelectedEvent")]
    public class CardSelectedEvent : ScriptableAction<IPlayer, ICard> { }
}
