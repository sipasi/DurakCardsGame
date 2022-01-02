using Framework.Shared.Cards.Entities;
using Framework.Shared.Events;

using UnityEngine;

namespace Framework.Shared.Cards.Events
{

    [CreateAssetMenu(fileName = "CardInteraction", menuName = "MyAsset/Shared/Cards/Events")]
    public class CardInteraction : ScriptableAction<ICard> { }
}
