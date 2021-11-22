﻿using ProjectCard.DurakModule.EntityModule;
using ProjectCard.DurakModule.ValidatorModule;
using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.EventModule;

using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectCard.DurakModule.PlayerModule
{
    public abstract class CardSelector : MonoBehaviour, ICardSelector
    {
        [SerializeField] private CardSelectorType type;

        [Header("Validators")]
        [SerializeField] private SelectionValidator selectionValidator;
        [SerializeField] private PassValidator passValidator;

        [Header("Events")]
        [SerializeField] private ScriptableAction<IPlayer, ICard> cardSelected;
        [SerializeField] private ScriptableAction<IPlayer> passAction;

        protected IPlayer Current { get; private set; }

        public CardSelectorType Type => type;

        public void Begin(IPlayer player)
        {
            Assert.IsNull(Current,
                $"{GetType().Name} can't take a player[{player.Name}] while last player[{Current?.Name ?? "null"}] will not be served");

            Current = player;

            Begin();
        }
        public void End(IPlayer player)
        {
            Assert.AreEqual(
                expected: Current,
                actual: player,
                message: $"Start with one player[{Current.Name}] and end with another[{player.Name}]");

            End();

            Current = null;
        }
        public virtual void Begin() { }
        public virtual void End() { }

        protected void SelectCard(ICard card)
        {
            if (selectionValidator.Validate(card) is false)
            {
                return;
            }

            cardSelected.Rise(Current, card);
        }
        protected void Pass() => OnPassAction(Current);

        private void OnPassAction(IPlayer player)
        {
            if (passValidator.Validate() is false)
            {
                Debug.Log($"Player[{player}] can't pass");
                return;
            }

            passAction.Rise(player);
        }
    }
}