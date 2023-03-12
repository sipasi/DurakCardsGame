using UnityEngine;
using UnityEngine.UI;

namespace Framework.Shared.Cards.Entities
{
    public class CardPrefab : MonoBehaviour
    {
        [field: SerializeField] public Image Image { get; private set; }
        [field: SerializeField] public Transform Transform { get; private set; }
    }
}