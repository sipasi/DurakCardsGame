using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public class PlayerCardSelection : MonoBehaviour, IPlayerCardSelection
    {
        [SerializeField] private CardSelectorType type;

        [SerializeField] private CardSelector attack;
        [SerializeField] private CardSelector defend;

        public CardSelectorType Type => type;

        public ICardSelector Attack => attack;
        public ICardSelector Defend => defend;
    }
}