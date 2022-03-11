using Framework.Shared.Cards.Entities;

using UnityEngine.Assertions;

namespace Framework.Durak.Players.Selectors
{
    public abstract class CardSelector : ICardSelector
    {
        public event CardSelectedEventHandler Selected;
        public event PlayerPassedEventHandler Passed;

        protected IPlayer Current { get; private set; }

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

        protected void SelectCard(ICard card) => SelectCard(Current, card);
        protected void SelectCard(IPlayer player, ICard card)
        {
            Assert.AreEqual(player, Current);

            Selected.Invoke(player, card);
        }

        protected void Pass() => Pass(Current);
        protected void Pass(IPlayer player)
        {
            Assert.AreEqual(player, Current);

            Passed.Invoke(player);
        }
    }
}