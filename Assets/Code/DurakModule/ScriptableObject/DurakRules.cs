
using UnityEngine;

namespace ProjectCard.DurakModule.ScriptableModule
{
    [CreateAssetMenu(fileName = "DurakRules", menuName = "MyAsset/Durak/ScriptableModule/DurakRules")]
    public class DurakRules : ScriptableObject
    {
        [SerializeField] private int maxCardsInHand;

        public int MaxCardsInHand => maxCardsInHand;
    }
}