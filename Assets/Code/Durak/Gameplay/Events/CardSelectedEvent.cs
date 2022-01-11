
using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Events;

using UnityEngine;

namespace Framework.Durak.Gameplay.Events
{
    [CreateAssetMenu(fileName = "CardSelectedEvent", menuName = "MyAsset/Durak/Gameplay/Events/CardSelectedEvent")]
    public class CardSelectedEvent : ScriptableAction<IPlayer, ICard> { }
}
