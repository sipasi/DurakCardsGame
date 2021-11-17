using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.ValidatorModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;

namespace ProjectCard.DurakModule.PlayerModule
{
    public abstract class CardSelector : MonoBehaviour, ICardSelector
    {
        [SerializeField] private CardSelectorType type;
        [SerializeField] private PlayerEntity player;

        [Header("Validators")]
        [SerializeField] private SelectionValidator selectionValidator;
        [SerializeField] private PassValidator passValidator;

        [Header("Events")]
        [SerializeField] private ScriptableAction<IPlayer, ICard> cardSelected;
        [SerializeField] private ScriptableAction<IPlayer> passAction;

        protected IPlayer Player => player.Entity;

        public CardSelectorType Type => type;

        public virtual void Begin() { }
        public virtual void End() { }

        protected void SelectCard(ICard card)
        {
            if (selectionValidator.Validate(card) is false)
            {
                return;
            }

            cardSelected.Rise(Player, card);
        }
        protected void Pass() => OnPassAction(Player);

        private void OnPassAction(IPlayer player)
        {
            if (passValidator.Validate() is false)
            {
                return;
            }

            passAction.Rise(player);
        }
    }
}