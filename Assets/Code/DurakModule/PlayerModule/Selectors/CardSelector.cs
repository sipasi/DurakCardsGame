using ProjectCard.DurakModule.ValidatorModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public abstract class CardSelector : MonoBehaviour, ICardSelector
    {
        [SerializeField] private PlayerInfo player;

        [Header("Validators")]
        [SerializeField] private SelectionValidator selectionValidator;
        [SerializeField] private PassValidator passValidator;

        [Header("Events")]
        [SerializeField] private ScriptableAction<PlayerInfo, ICard> cardSelected;
        [SerializeField] private ScriptableAction<PlayerInfo> passAction;

        protected PlayerInfo Player => player;

        public virtual void Begin() { }
        public virtual void End() { }

        protected void SelectCard(ICard card)
        {
            selectionValidator.Validate(card);

            cardSelected.Rise(player, card);
        }
        protected void Pass() => OnPassAction(player);

        private void OnPassAction(PlayerInfo player)
        {
            if (passValidator.Validate() is false)
            {
                return;
            }

            passAction.Rise(player);
        }
    }
}