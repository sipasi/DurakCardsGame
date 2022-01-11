using Framework.Durak.Players;

using UnityEngine;

namespace Framework.Durak.Cards.Selectors
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