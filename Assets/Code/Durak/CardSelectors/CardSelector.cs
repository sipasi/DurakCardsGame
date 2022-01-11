using Framework.Durak.Players;
using Framework.Shared.Cards.Entities;
using Framework.Shared.Events;

using UnityEngine;
using UnityEngine.Assertions;

namespace Framework.Durak.Cards.Selectors
{
    public abstract class CardSelector : MonoBehaviour, ICardSelector
    {
        [Header("Events")]
        [SerializeField] private ScriptableAction<IReadonlyPlayer, ICard> cardSelected;
        [SerializeField] private ScriptableAction<IReadonlyPlayer> passAction;

        protected IReadonlyPlayer Current { get; private set; }

        public void Begin(IReadonlyPlayer player)
        {
            Assert.IsNull(Current,
                $"{GetType().Name} can't take a player[{player.Name}] while last player[{Current?.Name ?? "null"}] will not be served");

            Current = player;

            Begin();
        }
        public void End(IReadonlyPlayer player)
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

        protected void SelectCard(ICard card) => cardSelected.Rise(Current, card);

        protected void Pass() => OnPassAction(Current);

        private void OnPassAction(IReadonlyPlayer player) => passAction.Rise(player);

    }
}