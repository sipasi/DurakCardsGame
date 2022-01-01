
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;

namespace ProjectCard.Shared.Cards.Events
{

    [CreateAssetMenu(fileName = "CardInteraction", menuName = "MyAsset/Shared/Cards/Events")]
    public class CardInteraction : ScriptableAction<ICard> { }
}
