
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.Shared.CardModule
{
    public class CardEntity : MonoBehaviour, ICard
    {
        [field: SerializeField] public CardView View { get; private set; }
        [field: SerializeField] public Transform Transform { get; private set; }
    }
}