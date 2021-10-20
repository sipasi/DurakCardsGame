using ProjectCard.Shared.CardModule;
using ProjectCard.Shared.ViewModule;

using UnityEngine;

namespace ProjectCard.Shared.ServiceModule.MovementModule
{
    class Preparation
    {
        public void BeforeMovement(ICard card, ICard temporary, Transform parent)
        {
            CopyView(from: card.View, to: temporary.View);

            Activator(card, view: false, input: false);

            CopyPosition(from: card.Transform, to: temporary.Transform);

            Activator(temporary, view: true, input: false);

            card.Transform.SetParent(parent);
            card.Transform.localPosition = default;
        }

        public void AfterMovement(ICard card, ICard temporary)
        {
            Activator(card, view: true, input: true);

            Activator(temporary, view: false, input: false);
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

        private void Activator(ICard card, bool view, bool input)
        {
            card.View.IsVisible = view;
            //TODO: card.Input.Interactable = input;
        }
    }
}