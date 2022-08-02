
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Shared.Cards.Entities
{
    public class CardEntity : MonoBehaviour, ICard
    {
        [field: SerializeField] public CardView View { get; private set; }
        [field: SerializeField] public Transform Transform { get; private set; }

        [field: SerializeField] public bool InputSensitive { get; private set; }
    }
}