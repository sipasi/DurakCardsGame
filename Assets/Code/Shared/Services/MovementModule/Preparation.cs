using Framework.Shared.Cards.Entities;
using Framework.Shared.Cards.Views;

using UnityEngine;

namespace Framework.Shared.Services.Movements
{
    internal class Preparation
    {
        public void BeforeMovement(ICard temporary, ICard card, Transform parent)
        {
            CopyView(from: card.View, to: temporary.View);

            Activator(card, view: false);

            CopyPosition(from: card.Transform, to: temporary.Transform);

            Activator(temporary, view: true);

            card.Transform.SetParent(parent);
            card.Transform.localPosition = default;
        }

        public void AfterMovement(ICard temporary, ICard card)
        {
            Activator(card, view: true);

            Activator(temporary, view: false);
        }

        private void CopyView(CardView from, CardView to)
        {
            to.Face = from.Face;
            to.Back = from.Back;
            to.LookSide = from.LookSide;
        }
        private void CopyPosition(Transform from, Transform to)
        {
            to.position = from.position;
        }

        private void Activator(ICard card, bool view)
        {
            card.View.IsVisible = view;
        }
    }
}