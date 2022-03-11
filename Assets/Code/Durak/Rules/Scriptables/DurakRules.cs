
using UnityEngine;

namespace Framework.Durak.Rules.Scriptables
{
    [CreateAssetMenu(fileName = "DurakRules", menuName = "MyAsset/Durak/Gameplay/Scriptables/DurakRules")]
    public class DurakRules : ScriptableObject, IDurakRules
    {
        [SerializeField] private int maxCardsInHand = 6;

        public int MaxCardsInHand => maxCardsInHand;
    }
}
