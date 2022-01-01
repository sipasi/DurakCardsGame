using UnityEngine;

namespace ProjectCard.Durak.PlayerModule
{
    public class PlayerCardSelection : MonoBehaviour, IPlayerCardSelection
    {
        [SerializeField] private PlayerType type;

        [SerializeField] private CardSelector attack;
        [SerializeField] private CardSelector defend;

        public PlayerType Type => type;

        public ICardSelector Attack => attack;
        public ICardSelector Defend => defend;
    }
}