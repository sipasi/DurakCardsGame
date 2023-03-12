using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;
namespace Framework.Shared.Services.Movements
{
    internal class Preparation
    {
        public void BeforeMovement(ICard temporary, ICard card, ICardOwner owner)
        {
            CopyView(from: card.View, to: temporary.View);

            Activator(card, view: false);

            CopyPosition(from: card.Navigation, to: temporary.Navigation);

            Activator(temporary, view: true);

            owner.Take(card);
        }

        public void AfterMovement(ICard temporary, ICard card)
        {
            Activator(card, view: true);

            Activator(temporary, view: false);
        }

        private void CopyView(ICardView from, ICardView to)
        {
            to.Face = from.Face;
            to.Back = from.Back;
            to.LookSide = from.LookSide;
        }
        private void CopyPosition(ICardNavigation from, ICardNavigation to)
        {
            to.Position = from.Position;
        }

        private void Activator(ICard card, bool view)
        {
            card.View.IsVisible = view;
        }
    }
}